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
        public const string FriendlyDownloadLink = "https://dotnet.microsoft.com/download/dotnet/5.0";

        private const string DownloadLink =
            "https://download.visualstudio.microsoft.com/download/pr/55bb1094-db40-411d-8a37-21186e9495ef/1a045e29541b7516527728b973f0fdef/windowsdesktop-runtime-5.0.1-win-x86.exe";

        private static readonly string FileSavePath = Path.Combine(Paths.Temp, "ClausaComm_dotnet_installer.exe");
        public static bool Downloading { get; private set; }

        public static bool Downloaded
        {
            get { return File.Exists(FileSavePath); }
        }

        private static readonly ProcessStartInfo InstallStartInfo =
            ConsoleUtils.GetProcessStartInfo('"' + FileSavePath + '"' + " /q /noreboot", false, true);


        public static void DownloadDotnetAsync(DownloadProgressChangedEventHandler progressUpdateCallback,
            AsyncCompletedEventHandler downloadFinishedCallback)
        {
            if (Downloaded)
                downloadFinishedCallback.Invoke(null, new AsyncCompletedEventArgs(null, true, null));

            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += progressUpdateCallback;
                client.DownloadFileCompleted += downloadFinishedCallback;
                client.DownloadFileCompleted += (o, e) => Downloading = false;

                Downloading = true;
                client.DownloadFileAsync(new Uri(DownloadLink), FileSavePath);
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
                    ConsoleUtils.LogAsync(e);
                    success = false;
                }

                installationFinishedCallback.Invoke(success);
            }, false);
        }
    }
}