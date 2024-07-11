using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Handlers
{
    public static class LogHandler
    {
        private static string LogPath {  get; set; }
        private static string LogFileName { get; set; }
        private static StreamWriter LogWriter { get; set; }

        public static void StartLog()
        {
            if (LogWriter != null)
                LogWriter.Close();

            if (LogPath == null)
                LogPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Recon ReTuned Logs\\";

            LogFileName = $"DCGReconLogger_{DateTime.Now.ToString("MMddyyyy")}_{DateTime.Now.ToString("hh-mm-ss-tt").ToUpper()}.log";

            if (!Directory.Exists(LogPath))
                Directory.CreateDirectory(LogPath);

            string logFilePath = Path.Combine(LogPath, LogFileName);

            int count = 1;
            while (File.Exists(logFilePath))
            {
                LogFileName = $"DCGReconLogger_{DateTime.Now.ToString("MMddyyyy")}_{DateTime.Now.ToString("hh-mm-ss-tt").ToLower()} ({count}).log";
                logFilePath = Path.Combine(LogPath, LogFileName);
                count++;
            }
            LogWriter = new StreamWriter(logFilePath, true);
            LogWriter.WriteLine($"[{DateTime.Now.ToString("MM/dd/yy hh:mm:sstt").ToLower()}] Logger Started.");
        }
        public static void StopLog()
        {
            if (LogWriter != null)
            {
                LogWriter.WriteLine($"[{DateTime.Now.ToString("MM/dd/yy hh:mm:sstt").ToLower()}] Logger Stopped.");
                LogWriter.Close();
            }
        }
        public static void LogMessage(string message)
        {
            if (LogWriter != null)
            {
                message = $"[{DateTime.Now.ToString("MM/dd/yy hh:mm:sstt").ToLower()}] {message}";
                LogWriter.WriteLine(message);
            }
        }
    }
}
