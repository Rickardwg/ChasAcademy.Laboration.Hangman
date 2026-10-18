namespace Hangman;

internal class HangmanGame
{
    private readonly List<string> _words = ["foo", "bar", "baz"];
    private string _secretWord = string.Empty;
    private const int _maxGuesses = 6;
    internal HashSet<char> GuessedLetters { get; private set; } = []; // AI
    internal int IncorrectGuesses { get; private set; } = 0;

    internal void InitializeSecretWord()
    {
        var index = Random.Shared.Next(_words.Count);
        _secretWord = _words[index];
    }

    internal bool CheckGuess(char guess)
    {
        guess = char.ToLowerInvariant(guess);

        if (GuessedLetters.Contains(guess))
        {
            return false;
        }

        GuessedLetters.Add(guess);

        if (!_secretWord.Contains(guess))
        {
            IncorrectGuesses++;
        }

        return true;
    }

    internal string GetDisplayWord()
    {
        return new string([.. _secretWord.Select(letter => GuessedLetters.Contains(letter) ? letter : '_')]); // AI
    }

    internal bool HasWon()
    {
        return _secretWord.All(letter => GuessedLetters.Contains(letter));
    }

    internal bool HasLost()
    {
        return IncorrectGuesses == _maxGuesses;
    }
}
