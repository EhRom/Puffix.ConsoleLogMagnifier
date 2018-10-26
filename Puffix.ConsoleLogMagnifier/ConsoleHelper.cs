using System;

namespace Puffix.ConsoleLogMagnifier
{
    /// <summary>
    /// Helper to magnify logs in your Console Application (.Net and .Net Core).
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Add new line.
        /// </summary>
        [Obsolete("Use WriteNewLine instead.")]
        public static void WriteLine(uint lineCount = 1)
        {
                Console.WriteLine();
        }
        /// <summary>
        /// Add new line.
        /// </summary>
        public static void WriteNewLine(uint lineCount = 1)
        {
            for (uint i = 0; i < lineCount; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Display message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void Write(string message)
        {
            CoreWriteMessage(ConsoleColor.White, message);
        }

        /// <summary>
        /// Display verbose message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void WriteVerbose(string message)
        {
            CoreWriteMessage(ConsoleColor.Gray, message);
        }

        /// <summary>
        /// Display information message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void WriteInfo(string message)
        {
            CoreWriteMessage(ConsoleColor.Cyan, message);
        }

        /// <summary>
        /// Display success message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void WriteSuccess(string message)
        {
            CoreWriteMessage(ConsoleColor.Green, message);
        }

        /// <summary>
        /// Display warning message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void WriteWarning(string message)
        {
            CoreWriteMessage(ConsoleColor.Yellow, message);
        }

        /// <summary>
        /// Display error message.
        /// </summary>
        /// <param name="message">Message.</param>
        public static void WriteError(string message)
        {
            CoreWriteMessage(ConsoleColor.Red, message);
        }

        /// <summary>
        /// Display error.
        /// </summary>
        /// <param name="error">Error.</param>
        public static void WriteError(Exception error)
        {
            CoreWriteMessage(ConsoleColor.Red, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
            if (error.InnerException != null)
                WriteError(error.InnerException);
        }
        
        /// <summary>
        /// Display error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="error">Error.</param>
        public static void WriteError(string message, Exception error)
        {
            CoreWriteMessage(ConsoleColor.Red, message);
            CoreWriteMessage(ConsoleColor.Red, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
            if (error.InnerException != null)
                WriteError(error.InnerException);
        }

        /// <summary>
        /// Display message.
        /// </summary>
        /// <param name="color">Foreground (text) color.</param>
        /// <param name="message">Message.</param>
        private static void CoreWriteMessage(ConsoleColor color, string message)
        {
            ConsoleColor savedColor = Console.ForegroundColor;
            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ForegroundColor = savedColor;
        }
    }
}
