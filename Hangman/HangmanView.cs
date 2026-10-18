namespace Hangman;

internal class HangmanView
{
    // ASCII-art was generated with AI.
    private readonly string[] _hangmanStages =
    [
        "",
        """
          +---+
          |
          |
          |
          |
        __|___
        """,
        """
          +---+
          |   |
          |   O
          |
          |
        __|___
        """,
        """
          +---+
          |   |
          |   O
          |   |
          |
        __|___
        """,
        """
          +---+
          |   |
          |   O
          |  /|
          |
        __|___
        """,
        """
          +---+
          |   |
          |   O
          |  /|\
          |
        __|___
        """,
        """
          +---+
          |   |
          |   O
          |  /|\
          |  / \
        __|___
        """
    ];

    internal void DisplayHeader()
    {
        Console.WriteLine("==================== HANGMAN ====================");
    }

    internal void DisplayHangman(int incorrectGuesses)
    {
        Console.WriteLine(_hangmanStages[incorrectGuesses]);
    }

    internal void DisplaySecretWord(string secretWord)
    {
        Console.WriteLine($"SECRET WORD: {secretWord}");
    }

    internal void DisplayGuessedLetters(IEnumerable<char> guessedLetters)
    {
        Console.Write("GUESSED LETTERS: ");
        foreach (char c in guessedLetters)
        {
            Console.Write(c + " ");
        }
        Console.WriteLine();
    }

    internal void DisplayWinMessage()
    {
        Console.WriteLine("YOU WIN!");
    }

    internal void DisplayLoseMessage()
    {
        Console.WriteLine("YOU LOSE!");
    }

    internal void DisplayError(string error)
    {
        Console.WriteLine(error);
    }

    internal char ReadGuess()
    {
        string? input;
        do
        {
            Console.Write("Enter: ");
            input = Console.ReadLine();
        } while (input.Length != 1 || input.Any(c => !char.IsLetter(c)));

        return char.Parse(input);
    }

    internal char ReadPlayAgainResponse()
    {
        string? input;
        do
        {
            Console.Write("Play Again? (y/n): ");
            input = Console.ReadLine().ToLowerInvariant();
        } while (input != "y" && input != "n");

        return char.Parse(input);
    }
}
