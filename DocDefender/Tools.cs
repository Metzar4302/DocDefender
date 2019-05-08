using System;

namespace DocDefender
{
    public static class Tools
    {
        public static int difficult = 4;
        public static void WriteLineColorized(string message, ConsoleColor color){
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public static void WriteColorized(string message, ConsoleColor color){
            lock (Console.Out)
            {
                Console.ForegroundColor = color;
                Console.Write(message);
                Console.ResetColor();
            }
        }

        public static void ChainView(Blockchain blockChain){
            foreach (Block item in blockChain.Chain) {
                Console.WriteLine($"{item}");
            }
        }
    }
}