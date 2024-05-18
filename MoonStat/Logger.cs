using System;
using System.ComponentModel;
using System.IO;

namespace MoonStat
{
    public interface ILogs
    {
        void LogInfo(string component, string message);
        void LogError(string component, string message);
        void LogWarning(string component, string message);
    }

    public class Logger : ILogs
    {
        private static readonly string logFilePath = "LogFile.txt"; // Define o caminho do arquivo de log

        public void LogInfo(string component, string message)
        {
            Log("INFO", component, message);
        }

        public void LogError(string component, string message)
        {
            Log("ERROR", component, message);
        }

        public void LogWarning(string component, string message)
        {
            Log("WARNING", component, message);
        }

        private void Log(string logLevel, string component, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] [{component}] {message}";
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
