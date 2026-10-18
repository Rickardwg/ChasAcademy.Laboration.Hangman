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

    internal void DisplayHangman(int incorrectGuesses)
    {
        Console.WriteLine(_hangmanStages[incorrectGuesses]);
    }
}
