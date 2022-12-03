// Program: CSE 210 Tic Tac Toe Example

/// <summary>
/// This is a sample solution of the Tic Tac Toe program. It is not a
/// particularly sophisticated or elegant solution to the problem, but
/// rather it highlights a straightforward way to solve the problem
/// for a 3x3 game.
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        string currentPlayer = "x";

        while (!IsGameOver(board))
        {
            board.display();

            int choice = GetMoveChoice(currentPlayer);
            board.makeMove(choice, currentPlayer);

            currentPlayer = GetNextPlayer(currentPlayer);
        }

        board.display();
        Console.WriteLine("Good game. Thanks for playing!");
    }

    /// <summary>
    /// Determines if the game is over because of a win or a tie.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the game is over</returns>
    static bool IsGameOver(Board board)
    {
        bool isGameOver = false;

        if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
        {
            isGameOver = true;
        }

        return isGameOver;
    }

    /// <summary>
    /// Determines if the provided player has a tic tac toe.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="player">The player to check for a win</param>
    /// <returns></returns>
    static bool IsWinner(Board board, string player)
    {
        return board.isPlayerWinner(player);
    }

    /// <summary>
    /// Determines if the board is full with no more moves possible.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the board is full.</returns>
    static bool IsTie(Board board)
    {
        return !board.hasUnclaimedSquares();
    }

    /// <summary>
    /// Cycles through the players (from x to o and o to x)
    /// </summary>
    /// <param name="currentPlayer">The current players sign (x or o)</param>
    /// <returns>The next players sign (x or o)</returns>
    static string GetNextPlayer(string currentPlayer)
    {
        string nextPlayer = "x";

        if (currentPlayer == "x")
        {
            nextPlayer = "o";
        }

        return nextPlayer;
    }

    /// <summary>
    /// Gets the 1-based spot number associated with the user's choice.
    /// </summary>
    /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
    /// <returns>A 1-based spot number (not a 0-based index)</returns>
    static int GetMoveChoice(string currentPlayer)
    {
        Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
        string? move_string = Console.ReadLine();

        if (move_string is null) {
            return 0;
        }

        int choice = int.Parse(move_string);
        return choice;
    }
}