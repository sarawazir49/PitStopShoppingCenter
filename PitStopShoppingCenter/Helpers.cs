using System;

namespace PitStopShoppingCenter.Helpers
{
  
    public static class ConsoleHelper
    {
        // Prints a yellow header for sections
        public static void PrintHeader(string title)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; // Change text color to yellow
            Console.WriteLine($"\n=== {title.ToUpper()} ===");
            Console.ResetColor(); // Reset color back to default - important!
        }

        // Prints success message in green
        public static void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"✔ {msg}");
            Console.ResetColor();
        }

        // Prints error message in red
        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"✘ {msg}");
            Console.ResetColor();
        }

       
        public static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            // ASCII Art Logo - displayed every time menu is shown
            Console.WriteLine(@"
  ____  _____ _______   _____ _______ ____  _____
 |  _ \|_   _|__   __| / ____|__   __/ __ \|  __ \
 | |_) | | |    | |    \___ \  | | | |  | | |__) |
 |  __/  | |    | |     ___) | | | | |  | |  ___/
 | |    _| |_   | |    |____/  | | | |__| | |
 |_|   |_____|  |_|                \____/|_|
                                             
      P I T   S T O P   S H O P P I N G   C E N T E R
==================================================================");
            Console.ResetColor();
        }

        // Keeps asking until user enters something
        public static string ReadNonEmpty(string prompt)
        {
            string? input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim(); // Trim removes spaces
                if (string.IsNullOrEmpty(input)) Error("Cannot be empty!");
            } while (string.IsNullOrEmpty(input));
            return input;
        }

       
        public static decimal ReadPrice(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                // TryParse returns false if not a number, so no exception
                if (decimal.TryParse(Console.ReadLine(), out decimal p) && p > 0) return p;
                Error("Invalid price! Must be a number > 0");
            }
        }

        // Helper to read integer ID safely
        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int v)) return v;
                Error("Invalid number!");
            }
        }
    }
}