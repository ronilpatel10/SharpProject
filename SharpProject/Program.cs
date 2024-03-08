using System;

namespace SharpProject
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo(); // Display app info
            GreetUser(); // Ask for the user's name and greet

            while (true)
            {
                // Game setup
                Random random = new Random();
                int difficulty = GetDifficultyLevel();
                int maxNumber = difficulty * 10;
                int correctNumber = random.Next(1, maxNumber + 1);
                int guess = 0;
                Console.WriteLine($"Guess a number between 1 and {maxNumber}");

                // Guessing loop
                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    // Validate input as a number
                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an actual number.");
                        continue;
                    }

                    // Validate guess range
                    if (guess < 1 || guess > maxNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, $"Please enter a number between 1 and {maxNumber}.");
                        continue;
                    }

                    if (guess != correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Wrong number, please try again");
                    }
                }

                // Success message
                PrintColorMessage(ConsoleColor.Magenta, "You guessed it! Congratulations!");

                // Play again?
                if (!AskToPlayAgain())
                {
                    return;
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "4.2.0";
            string appAuthor = "Ronil Patel";

            PrintColorMessage(ConsoleColor.Green, $"{appName}: Version {appVersion} by {appAuthor}");
        }

        static void GreetUser()
        {
            Console.WriteLine("What is your name?");
            string inputName = Console.ReadLine();
            Console.WriteLine($"Hello {inputName}, let's play a game...");
        }

        static int GetDifficultyLevel()
        {
            Console.WriteLine("Choose difficulty level (1=Easy, 2=Medium, 3=Hard):");
            string level = Console.ReadLine();
            switch (level)
            {
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                default:
                    PrintColorMessage(ConsoleColor.Yellow, "Invalid level, defaulting to Easy (1).");
                    return 1;
            }
        }

        static bool AskToPlayAgain()
        {
            Console.WriteLine("Play Again? [Y or N]");
            string answer = Console.ReadLine().ToUpper();
            return answer == "Y";
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
