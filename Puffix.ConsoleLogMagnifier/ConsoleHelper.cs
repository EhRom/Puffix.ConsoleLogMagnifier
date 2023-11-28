using System;

namespace Puffix.ConsoleLogMagnifier;

/// <summary>
/// Helper to magnify logs in your Console Application (.Net and .Net Core).
/// </summary>
public static class ConsoleHelper
{
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
    /// Display message.
    /// </summary>
    /// <param name="textColor">Color of the text to display</param>
    /// <param name="message">Message.</param>
    public static void Write(ConsoleColor textColor, string message)
    {
        CoreWriteMessage(textColor, message);
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
    /// Display error as information.
    /// </summary>
    /// <param name="error">Error.</param>
    public static void WriteInfo(Exception error)
    {
        CoreWriteMessage(ConsoleColor.Cyan, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
        if (error.InnerException != null)
            WriteInfo(error.InnerException);
    }

    /// <summary>
    /// Display error as information.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="error">Error.</param>
    public static void WriteInfo(string message, Exception error)
    {
        CoreWriteMessage(ConsoleColor.Cyan, message);
        CoreWriteMessage(ConsoleColor.Cyan, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
        if (error.InnerException != null)
            WriteInfo(error.InnerException);
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
    /// Display error as warning.
    /// </summary>
    /// <param name="error">Error.</param>
    public static void WriteWarning(Exception error)
    {
        CoreWriteMessage(ConsoleColor.Yellow, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
        if (error.InnerException != null)
            WriteWarning(error.InnerException);
    }

    /// <summary>
    /// Display error as warning.
    /// </summary>
    /// <param name="message">Message.</param>
    /// <param name="error">Error.</param>
    public static void WriteWarning(string message, Exception error)
    {
        CoreWriteMessage(ConsoleColor.Yellow, message);
        CoreWriteMessage(ConsoleColor.Yellow, $"Date : {DateTime.Now} - Type : {error.GetType()} / Message : {error.Message}");
        if (error.InnerException != null)
            WriteWarning(error.InnerException);
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
    /// Delete the last characters from the console.
    /// </summary>
    /// <param name="charactersCount">Character count to delete.</param>
    public static void ClearLastCharacters(uint charactersCount = 1)
    {
        for (uint i = 0; i < charactersCount; i++)
        {
            Console.Write('\b');
        }
    }

    /// <summary>
    /// Delete the last lines from the console.
    /// </summary>
    /// <param name="lineCount">Line count to delete.</param>
    public static void ClearLastLines(uint lineCount = 1)
    {
        for (uint i = 0; i < lineCount; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);

            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
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
