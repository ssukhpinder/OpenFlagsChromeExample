using OpenBrowserFromConsole.Intefrface;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace OpenBrowserFromConsole
{
    class Program
    {
        public static class ChromFlags
        {
            public static string NewWindow { get { return "--new-window"; } }
            public static string Incognito { get { return "--incognito"; } }
            public static string DisableSync { get { return "–-disable-sync"; } }
            public static string EnableNightLight { get { return "–ash-enable-night-light"; } }
            public static string DisableBackgroundMode { get { return "-–disable-background-mode"; } }
            public static string AllowOutdatedPlugins { get { return "-–allow-outdated-plugins"; } }
            public static string DisableTranslate { get { return "––disable-translate"; } }
            public static string PurgeMemoryButton { get { return "––purge-memory-button"; } }
            public static string StartMaximized { get { return "-–start-maximized"; } }
            public static string DisableGpu { get { return "-–disable-gpu"; } }
            public static string DNSPrefetchDisable { get { return "––dns-prefetch-disable"; } }
            public static string RestoreLastSession { get { return "–-restore-last-session"; } }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            string url = "https://medium.com/@singhsukhpinder13";

            OpenDefaultBrowser(url);
            OpenChromeWithFlags(url, true, ChromFlags.StartMaximized);
        }
        public static void OpenDefaultBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
        }

        public static void OpenChromeWithFlags(string url, bool isFlagEnabled = false, string chromeFlag = "")
        {
            Process process = new Process();
            process.StartInfo.FileName = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe";
            process.StartInfo.Arguments = url + (isFlagEnabled ? " " + chromeFlag : "");
            process.Start();
        }

    }
}
