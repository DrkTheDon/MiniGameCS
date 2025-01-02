using System;
using System.Threading;

class MiniGameCSharp
{
    // Global Variables
    static int paper;
    static int rock;
    static int scissors;



    static void Game()
    {
        Random random = new Random(); // Random generator
        int computerChoiceRpc;
        int playerChoiceRpc;

        // Rock, Paper, Scissors Game
        while (true)
        {
            // Generate random choice for the computer
            computerChoiceRpc = random.Next(1, 4); // Generate random number [1, 3]

            // Print game options
            Console.Clear();
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");
            Console.WriteLine("[1] Rock");
            Console.WriteLine("[2] Paper");
            Console.WriteLine("[3] Scissors");
            Console.WriteLine("[4] Quit");
            Console.Write("\nEnter your choice: ");

            // Input validation
            if (!int.TryParse(Console.ReadLine(), out playerChoiceRpc))
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                Thread.Sleep(2000);
                continue;
            }

            // Game logic
            Console.Clear();
            if (playerChoiceRpc == 4)
            {
                Console.WriteLine("Thanks for playing!");
                Thread.Sleep(2000);
                break; // Exit the game
            }

            if (playerChoiceRpc < 1 || playerChoiceRpc > 4)
            {
                Console.WriteLine("Invalid choice");
                Thread.Sleep(2000);
                continue;
            }

            // Determine the outcome
            if (playerChoiceRpc == computerChoiceRpc)
            {
                Console.WriteLine($"It's a tie, you both chose {GetChoiceName(playerChoiceRpc)}");
            }
            else if (
                (playerChoiceRpc == 1 && computerChoiceRpc == 3) || // Rock beats Scissors
                (playerChoiceRpc == 2 && computerChoiceRpc == 1) || // Paper beats Rock
                (playerChoiceRpc == 3 && computerChoiceRpc == 2)    // Scissors beats Paper
            )
            {
                Console.WriteLine($"You win! CPU chose {GetChoiceName(computerChoiceRpc)}");
            }
            else
            {
                Console.WriteLine($"You lose! CPU chose {GetChoiceName(computerChoiceRpc)}");
            }

            Thread.Sleep(2000); // Wait for 2 seconds before restarting
        }
    }

    static void ChoiceMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to MiniGameCSharp!\n");
            Console.WriteLine("[1] Rock Paper Scissors");
            Console.WriteLine("[2] Tic Tac Toe");
            Console.WriteLine("[3] Hangman");
            Console.WriteLine("[4] Number Guessing Game");
            Console.WriteLine("[5] Blackjack");
            Console.WriteLine("[6] Connect Four");
            Console.WriteLine("[7] Quit");
            Console.Write("\nEnter your choice: ");

            // Input validation
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.Clear();
                Console.WriteLine("Invalid input");
                Thread.Sleep(2000);
                continue;
            }

            // Handle user choice
            Console.Clear();
            switch (choice)
            {
                case 1:
                    Game();
                    break;

                case 2:
                    Console.WriteLine("Tic Tac Toe is under development.");
                    Thread.Sleep(2000);
                    break;

                case 3:
                    hangman();
                    break;

                case 4:
                    Console.WriteLine("Number Guessing Game is under development.");
                    Thread.Sleep(2000);
                    break;

                case 5:
                    Console.WriteLine("Blackjack is under development.");
                    Thread.Sleep(2000);
                    break;

                case 6:
                    Console.WriteLine("Connect Four is under development.");
                    Thread.Sleep(2000);
                    break;

                case 7:
                    Console.WriteLine("Thanks for playing!");
                    Thread.Sleep(2000);
                    Environment.Exit(0); // Exit the program
                    break;

                default:
                    Console.WriteLine("Invalid choice");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }

    // Helper function to convert choice number to string
    static string GetChoiceName(int choice)
    {
        return choice switch
        {
            1 => "Rock",
            2 => "Paper",
            3 => "Scissors",
            _ => "Unknown"
        };
    }

    static void hangman()
    {
        string[] words = { "COMPUTER", "PROGRAMMING", "SOFTWARE", "DEBUGGING", "COMPILER", "DEVELOPER", "ALGORITHM", "APPLICATION" };
        Random random = new Random();
        string wordToGuess = words[random.Next(0, words.Length)];
        char[] wordState = new char[wordToGuess.Length];
        int tries = 0;
        bool wordIsGuessed = false;
        int lettersGuessed = 0;
        int maxTries = 15;

        // Initialize word state
        for (int i = 0; i < wordState.Length; i++)
        {
            wordState[i] = '_';
        }

        // Game loop
        while (!wordIsGuessed && tries < maxTries)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Hangman!");
            Console.WriteLine("Current word: " + string.Join(" ", wordState));
            Console.WriteLine("Tries remaining: " + (maxTries - tries));
            Console.WriteLine("Enter a letter: ");
            char input = Console.ReadLine()[0];
            input = Char.ToUpper(input); // Make all the chars uppercase
            // Check if the letter has already been guessed
            bool letterGuessed = false;
            for (int i = 0; i < wordState.Length; i++)
            {
                if (wordToGuess[i] == input)
                {
                    wordState[i] = input;
                    lettersGuessed++;
                    letterGuessed = true;
                }
            }
            if (!letterGuessed)
            {
                tries++;
            }
            // Check if the word has been guessed
            if (lettersGuessed == wordState.Length)
            {
                wordIsGuessed = true;
            }
        }
        Console.Clear();
        if (wordIsGuessed)
        {
            Console.WriteLine("Congratulations! You guessed the word: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("Out of tries! The word was: " + wordToGuess);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.WriteLine("Would you like to play again? (yes/no)");
        string response = Console.ReadLine();
        if (response == "yes")
        {
            hangman();
        }

    }
    static void Main(string[] args)
    {
        ChoiceMenu(); // Entry point
    }
}
