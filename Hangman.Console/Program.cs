using System.Linq;

namespace Hangman.Console
{
    internal class Program
    {
        private static void Main()
        {
            System.Console.Write("Please enter a word: ");

            var searchedWord = System.Console.ReadLine();
            System.Console.Clear();

            var hangman = new Core.Hangman(searchedWord);
            while (!hangman.GameFinished)
            {
                System.Console.Write($"Enter your guess {hangman.NumberOfGuesses + 1}: ");
                var guessedLetter = System.Console.ReadLine()?.FirstOrDefault();

                if (guessedLetter == null)
                {
                    continue;
                }

                var output = hangman.GuessLetter(guessedLetter.Value);

                System.Console.Clear();
                System.Console.WriteLine(output);
            }

            System.Console.WriteLine($"Congratulations! You won with {hangman.NumberOfGuesses} guess(es).");
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
