namespace Hangman;

internal class HangmanGame
{
    // words were generated with AI.
    private readonly List<string> _words = ["apple", "bridge", "castle", "dragon", "forest", "guitar", "island", "jungle", "knight", "lantern", "mountain", "puzzle", "rocket", "shadow", "thunder", "umbrella", "village", "whisper", "journey", "treasure"];
    private string _secretWord = string.Empty;
    private const int _maxGuesses = 6;
    internal HashSet<char> GuessedLetters { get; private set; } = []; // HashSet as datatype was suggested by AI, since it contains no duplicates and its elements are in no particular order.
    internal int IncorrectGuesses { get; private set; } = 0;

    internal void Reset()
    {
        GuessedLetters.Clear();
        IncorrectGuesses = 0;
    }
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
        return new string([.. _secretWord.Select(letter => GuessedLetters.Contains(letter) ? letter : '_')]); // LINQ syntax was written with help from AI.
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