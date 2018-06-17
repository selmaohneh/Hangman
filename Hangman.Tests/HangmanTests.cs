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

        [TestMethod]
        public void CorrectGuess()
        {
            var output = _hangman.GuessLetter('r');

            Assert.AreEqual("_ _ _ _ _ _ _ _ r", output);
        }

        [TestMethod]
        public void CorrectGuess_ThenWrongGuess()
        {
            var output = _hangman.GuessLetter('r');
            Assert.AreEqual("_ _ _ _ _ _ _ _ r", output);

            output = _hangman.GuessLetter('a');
            Assert.AreEqual("_ _ _ _ _ _ _ _ r", output);
        }

        [TestMethod]
        public void CorrectGuess_ThenWrongGuess_ThenCorrectGuess()
        {
            var output = _hangman.GuessLetter('r');
            Assert.AreEqual("_ _ _ _ _ _ _ _ r", output);

            output = _hangman.GuessLetter('a');
            Assert.AreEqual("_ _ _ _ _ _ _ _ r", output);

            output = _hangman.GuessLetter('e');
            Assert.AreEqual("_ e _ e _ _ _ e r", output);
        }

        [TestMethod]
        public void UpperCaseGuess()
        {
            var output = _hangman.GuessLetter('D');
            Assert.AreEqual("D _ _ _ _ _ _ _ _", output);
        }

        [TestMethod]
        public void LowerCaseGuessIsValid_EvenIfSearchedLetterIsUpperCase()
        {
            var output = _hangman.GuessLetter('d');
            Assert.AreEqual("D _ _ _ _ _ _ _ _", output);
        }

        [TestMethod]
        public void FullSampleGame()
        {
            var output = _hangman.GuessLetter('u');
            Assert.AreEqual("_ _ _ _ _ _ _ _ _", output);

            output = _hangman.GuessLetter('e');
            Assert.AreEqual("_ e _ e _ _ _ e _", output);

            output = _hangman.GuessLetter('n');
            Assert.AreEqual("_ e _ e _ _ _ e _", output);

            output = _hangman.GuessLetter('o');
            Assert.AreEqual("_ e _ e _ o _ e _", output);

            output = _hangman.GuessLetter('r');
            Assert.AreEqual("_ e _ e _ o _ e r", output);

            output = _hangman.GuessLetter('a');
            Assert.AreEqual("_ e _ e _ o _ e r", output);

            output = _hangman.GuessLetter('d');
            Assert.AreEqual("D e _ e _ o _ e r", output);

            output = _hangman.GuessLetter('l');
            Assert.AreEqual("D e _ e l o _ e r", output);

            output = _hangman.GuessLetter('p');
            Assert.AreEqual("D e _ e l o p e r", output);

            output = _hangman.GuessLetter('v');
            Assert.AreEqual("D e v e l o p e r", output);
        }
    }
}
