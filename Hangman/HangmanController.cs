namespace Hangman;

internal class HangmanController(HangmanGame game, HangmanView view)
{
    private readonly HangmanGame _game = game;
    private readonly HangmanView _view = view;
    internal void Play()
    {
        var playAgain = true;

        while (playAgain) // Play again feature suggested by AI, but implemented by me.
        {
            var gameOver = false;
            _game.Reset();
            _game.InitializeSecretWord();

            while (!gameOver)
            {
                Console.Clear();

                _view.DisplayHeader();
                _view.DisplayHangman(_game.IncorrectGuesses);

                var secretWord = _game.GetDisplayWord();
                _view.DisplaySecretWord(secretWord);

                var guessedLetters = _game.GuessedLetters;
                _view.DisplayGuessedLetters(guessedLetters);

                if (_game.HasWon())
                {
                    _view.DisplayWinMessage();
                    gameOver = true;
                    continue;
                }

                if (_game.HasLost())
                {
                    _view.DisplayLoseMessage();
                    gameOver = true;
                    continue;
                }

                while (!_game.CheckGuess(_view.ReadGuess()))
                {
                    _view.DisplayError("Letter has already been guessed!");
                }
            }
            
            var response = _view.ReadPlayAgainResponse();

            if (response == 'n')
            {
                playAgain = false;
            }
        }
    }
}
