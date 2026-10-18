namespace Hangman;

internal class HangmanView
{
    // AI
    private readonly string[] _hangmanStages =
    [
        """





        """,
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
        Console.WriteLine(secretWord);
    }

    internal void DisplayGuessedLetters(IEnumerable<char> guessedLetters)
    {
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
}
