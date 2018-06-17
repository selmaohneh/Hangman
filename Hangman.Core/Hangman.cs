using System.Linq;

namespace Hangman.Core
{
    public class Hangman
    {
        private readonly string _searchedWord;

        public Hangman(string searchedWord)
        {
            _searchedWord = searchedWord;
        }

        public string GuessLetter(char letter)
        {
            return "_ _ _ _ _ _ _ _ _";
        }
    }
}
