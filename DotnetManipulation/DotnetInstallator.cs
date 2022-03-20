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
        private static readonly string FileSavePath = Path.Combine(GlobalPaths.Temp, "ClausaComm_dotnet_installer.exe");
        private const string FriendlyDownloadLink = "https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.2-windows-x86-installer";
        private const string DownloadLink32 = "https://download.visualstudio.microsoft.com/download/pr/72ebbe8e-5175-41da-9046-1890732e0d5a/675ce08d0c1740142305d35692a8685b/windowsdesktop-runtime-6.0.2-win-x86.exe";
        private const string DownloadLink64 = "https://download.visualstudio.microsoft.com/download/pr/efa32b7a-6eec-4d97-9cdc-c7336a29a749/3df4296170397cf60884dae1be3d103b/windowsdesktop-runtime-6.0.2-win-x64.exe";

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

                client.DownloadFileAsync(new Uri(Environment.Is64BitOperatingSystem ? DownloadLink64 : DownloadLink32), FileSavePath);
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