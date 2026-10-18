namespace Hangman;

internal class HangmanController(HangmanGame game, HangmanView view)
{
    private readonly HangmanGame _game = game;
    private readonly HangmanView _view = view;
    internal void Play()
    {
        var isPlayAgain = true;
        

        while (isPlayAgain)
        {
            var isGameOver = false;
            _game.Reset();
            _game.InitializeSecretWord();

            while (!isGameOver)
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
                    isGameOver = true;
                    continue;
                }

                if (_game.HasLost())
                {
                    _view.DisplayLoseMessage();
                    isGameOver = true;
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
                isPlayAgain = false;
            }
        }
    }
}
