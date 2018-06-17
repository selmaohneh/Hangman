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
        public void AfterConstructor_GameIsRunning()
        {
            Assert.IsFalse(_hangman.GameFinished);
        }

        [TestMethod]
        public void WhenAllLettersGuessed_GameIsFinished()
        {
            var hangman = new Core.Hangman("a");
            hangman.GuessLetter('a');

            Assert.IsTrue(hangman.GameFinished);
        }

        [TestMethod]
        public void AfterConstructor_NumberOfGuessesIsZero()
        {
            Assert.AreEqual(0, _hangman.NumberOfGuesses);
        }

        [TestMethod]
        public void WhenGuessing_IncreaseNumberOfGuesses()
        {
            _hangman.GuessLetter('a');
            Assert.AreEqual(1, _hangman.NumberOfGuesses);

            _hangman.GuessLetter('d');
            Assert.AreEqual(2, _hangman.NumberOfGuesses);
        }

        [TestMethod]
        public void WhenGameIsFinished_DontIncrementNumberOfGuesses()
        {
            var hangman = new Core.Hangman("a");

            hangman.GuessLetter('b');
            Assert.AreEqual(1, hangman.NumberOfGuesses);

            hangman.GuessLetter('a');
            Assert.AreEqual(2, hangman.NumberOfGuesses);

            hangman.GuessLetter('c');
            Assert.AreEqual(2, hangman.NumberOfGuesses);

            hangman.GuessLetter('a');
            Assert.AreEqual(2, hangman.NumberOfGuesses);

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
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('e');
            Assert.AreEqual("_ e _ e _ _ _ e _", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('n');
            Assert.AreEqual("_ e _ e _ _ _ e _", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('o');
            Assert.AreEqual("_ e _ e _ o _ e _", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('r');
            Assert.AreEqual("_ e _ e _ o _ e r", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('a');
            Assert.AreEqual("_ e _ e _ o _ e r", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('d');
            Assert.AreEqual("D e _ e _ o _ e r", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('l');
            Assert.AreEqual("D e _ e l o _ e r", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('p');
            Assert.AreEqual("D e _ e l o p e r", output);
            Assert.IsFalse(_hangman.GameFinished);

            output = _hangman.GuessLetter('v');
            Assert.AreEqual("D e v e l o p e r", output);
            Assert.IsTrue(_hangman.GameFinished);
        }
    }
}
