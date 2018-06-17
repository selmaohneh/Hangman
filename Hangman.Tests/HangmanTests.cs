using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hangman.Tests
{
    [TestClass]
    public class HangmanTests
    {
        private Core.Hangman _hangman;

        [TestInitialize]
        public void Init()
        {
            _hangman = new Core.Hangman("Developer");
        }

        [TestMethod]
        public void WrongGuess()
        {
            var output = _hangman.GuessLetter('a');

            Assert.AreEqual("_ _ _ _ _ _ _ _ _", output);
        }
    }
}
