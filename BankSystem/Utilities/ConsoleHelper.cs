namespace BankingSystem.Utilities{
    public static class ConsoleHelper{
        public static void DisplayHeader(string title){
            Console.Clear();
            Console.WriteLine($"{title.PadLeft((60 + title.Length) / 2).PadRight(58)}");
            Console.WriteLine(new string('*', 60) + "\n");
        }

        public static void DisplaySuccess(string message){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        public static void DisplayError(string message){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {message}");
            Console.ResetColor();
        }

        public static void DisplayWarning(string message){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        public static string ReadString(string prompt){
            Console.Write(prompt);
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        public static decimal ReadDecimal(string prompt){
            while (true){
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value))
                    return value;

                DisplayError("Invalid number. Please try again.");
            }
        }

        public static int ReadInt(string prompt){
            while (true){
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                DisplayError("Invalid number. Please try again.");
            }
        }

        public static void PressEnterToContinue(){
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();
        }
    }
}
