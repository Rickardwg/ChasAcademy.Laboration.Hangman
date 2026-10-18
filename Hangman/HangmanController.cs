namespace Hangman;

internal class HangmanController(HangmanGame game, HangmanView view)
{
    private readonly HangmanGame _game = game;
    private readonly HangmanView _view = view;
    internal void Play()
    {
        _game.InitializeSecretWord();

        while (true)
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
                break;
            }

            if (_game.HasLost())
            {
                _view.DisplayLoseMessage();
                break;
            }

            while (!_game.CheckGuess(_view.ReadGuess()))
            {
                _view.DisplayError("Letter has already been guessed!");
            }
        }
    }
}
