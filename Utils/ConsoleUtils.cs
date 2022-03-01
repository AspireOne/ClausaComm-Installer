using System;
using System.Diagnostics;
using System.IO;

namespace ClausaComm_Installer.Utils
{
    public static class ConsoleUtils
    {
        //private static readonly Queue<object> QueuedMessages = new Queue<object>();
        public static bool ConsoleDisabled = false;
        private static bool LogFileDisabled = false;
        private static readonly string LogFilePath = Path.Combine(GlobalPaths.Temp, "ClausaComm_Installation_Log.log");
        private static readonly object LogLock = new object();

        public static ProcessStartInfo GetProcessStartInfo(string argument, bool fromSystem32, bool admin)
        {
            return new ProcessStartInfo
            {
                UseShellExecute = admin,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                RedirectStandardOutput = !admin,
                FileName = "cmd.exe",
                Arguments = "/C " + (fromSystem32 ? "cd " + GlobalPaths.System32 + " & " : "") + argument,
                Verb = admin ? "runas" : ""
            };
        }

        public static void RunProcess(string argument, bool fromSystem32, bool admin)
        {
            new Process { StartInfo = GetProcessStartInfo(argument, fromSystem32, admin) }.Start();
        }

        public static string GetDelay(int secs)
        {
            return "ping 127.0.0.1 -n " + (secs + 1) + " > nul";
        }


        public static void Log(object textObj)
        {
            string text = textObj.ToString();
            Debug.WriteLine(text);

            if (!ConsoleDisabled)
            {
                bool written = TryAndCatchAny(() => Console.WriteLine(text));
                if (!written)
                    ConsoleDisabled = true;
            }
            
            lock (LogLock)
            {
                bool logged = TryAndCatchAny(() => File.AppendAllText(LogFilePath, text + '\n'));
                if (!logged)
                    LogFileDisabled = true;
            }
        }

        private static bool TryAndCatchAny(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return false;
            }
        }
    }
}