using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using ClausaComm_Installer.Utils;

namespace ClausaComm_Installer.DotnetManipulation
{
    public static class DotnetInstallator
    {
        // C# 3
        // https://dotnet.microsoft.com/download/dotnet/thank-you/runtime-desktop-5.0.1-windows-x86-installer
        private static readonly string FileSavePath = Path.Combine(GlobalPaths.Temp, "ClausaComm_dotnet_installer.exe");
        private const string FriendlyDownloadLink = "https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime";
        private const string DownloadLink32 = "https://download.visualstudio.microsoft.com/download/pr/7977218c-1a01-4b69-a8ec-9d9311a6de5b/4c74f995295be78a9ebe1d5fede8f7f3/windowsdesktop-runtime-6.0.1-win-x86.exe";
        private const string DownloadLink64 = "https://download.visualstudio.microsoft.com/download/pr/bf058765-6f71-4971-aee1-15229d8bfb3e/c3366e6b74bec066487cd643f915274d/windowsdesktop-runtime-6.0.1-win-x64.exe";

        private static readonly ProcessStartInfo InstallStartInfo =
            ConsoleUtils.GetProcessStartInfo('"' + FileSavePath + '"' + " /q /noreboot", false, true);

        public static bool Downloaded
        {
            get { return File.Exists(FileSavePath); }
        }

        public static void DownloadDotnetAsync(DownloadProgressChangedEventHandler progressUpdateCallback, AsyncCompletedEventHandler downloadFinishedCallback)
        {
            if (Downloaded)
                downloadFinishedCallback.Invoke(null, new AsyncCompletedEventArgs(null, true, null));

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += progressUpdateCallback;
                client.DownloadFileCompleted += downloadFinishedCallback;

                client.DownloadFileAsync(new Uri(Environment.Is64BitProcess ? DownloadLink64 : DownloadLink32), FileSavePath);
            }
        }

        public static void DeleteDotnetInstallatorFile()
        {
            File.Delete(FileSavePath);
        }

        public static void OpenDotnetInstallWebsite()
        {
            Process.Start(FriendlyDownloadLink);
        }

        public static void InstallDotnetAsync(Action<bool> installationFinishedCallback)
        {
            if (!Downloaded)
                throw new Exception("Dotnet is not downloaded yet.");

            ThreadUtils.RunThread(() =>
            {
                bool success = true;
                var p = new Process {StartInfo = InstallStartInfo};
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception e)
                {
                    ConsoleUtils.Log(e);
                    success = false;
                }

                installationFinishedCallback.Invoke(success);
            }, false);
        }
    }
}