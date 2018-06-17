using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    internal class HangmanTests
    {
        private Core.Hangman _hangman;

        [TestInitialize]
        private void Init()
        {
            _hangman = new Core.Hangman("Developer");
        }
    }
}
