using System;
using System.IO;

namespace MoonStat
{
    public static class Logger
    {
        private static readonly string logFilePath = "LogFile.txt"; // Define o caminho do arquivo de log

        public static void LogInfo(string message)
        {
            Log("INFO", message);
        }

        public static void LogError(string message)
        {
            Log("ERROR", message);
        }

        private static void Log(string logLevel, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {message}";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                // Caso algo dê errado ao tentar escrever no log, você pode querer logar isso em algum lugar seguro
                Console.Error.WriteLine("Failed to log message: " + ex.Message);
            }
        }
    }
}
