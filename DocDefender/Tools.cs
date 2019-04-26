using System;

namespace DocDefender
{
    public class Tools
    {
        static void WriteLineColorized(string message, ConsoleColor color){
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }
}