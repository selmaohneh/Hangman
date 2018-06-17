using System.Collections.Generic;

namespace Hangman.Core
{
    public class Hangman
    {
        private readonly string _searchedWord;
        private readonly IList<char> _foundLetters = new List<char>();

        public Hangman(string searchedWord)
        {
            _searchedWord = searchedWord;
        }

        public bool GameFinished { get; private set; }
        public int NumberOfGuesses { get; private set; }

        public string GuessLetter(char guessedLetter)
        {
            if (!GameFinished)
            {
                NumberOfGuesses++;
            }

            if (GuessIsCorrect(guessedLetter))
            {
                AddToFoundLetters(guessedLetter);
            }

            if (AllLettersFound())
            {
                GameFinished = true;
            }

            var output = GenerateOutput();

            return output;
        }

        private bool GuessIsCorrect(char guessedLetter)
        {
            return _searchedWord.ContainsLetterAsLowerOrUpper(guessedLetter);
        }

        private void AddToFoundLetters(char guessedLetter)
        {
            if (!_foundLetters.ContainsLetterAsLowerOrUpper(guessedLetter))
            {
                _foundLetters.Add(guessedLetter);
            }
        }

        private bool AllLettersFound()
        {
            foreach (var searchedLetter in _searchedWord)
            {
                if (!_foundLetters.ContainsLetterAsLowerOrUpper(searchedLetter))
                {
                    return false;
                }
            }

            return true;
        }

        private string GenerateOutput()
        {
            var output = "";
            for (var index = 0; index < _searchedWord.Length; index++)
            {
                var searchedLetter = _searchedWord[index];

                if (index != 0)
                {
                    output += " ";
                }

                if (_foundLetters.ContainsLetterAsLowerOrUpper(searchedLetter))
                {
                    output += searchedLetter;
                }
                else
                {
                    output += "_";
                }
            }

            return output;
        }
    }

    internal static class Extensions
    {
        public static bool ContainsLetterAsLowerOrUpper(this IList<char> letters, char letter)
        {
            return letters.Contains(char.ToLowerInvariant(letter)) 
                   || letters.Contains(char.ToUpperInvariant(letter));
        }

        public static bool ContainsLetterAsLowerOrUpper(this string word, char letter)
        {
            return word.ToCharArray().ContainsLetterAsLowerOrUpper(letter);
        }
    }
}
