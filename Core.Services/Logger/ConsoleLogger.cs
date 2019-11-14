using Core.Interfaces;
using System;

namespace Core.Services.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Debug(string message)
        {
            this.Log($"DEBUG: {message}");
        }

        public void Error(string message)
        {
            this.Log($"ERROR: {message}");
        }

        public void Fatal(string message)
        {
            this.Log($"FATAL: {message}");
        }

        public void Info(string message)
        {
            this.Log($"INFO: {message}");
        }

        public void Warn(string message)
        {
            this.Log($"WARN: {message}");
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}