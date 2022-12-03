class Board {

    List<string> squares = new List<string>();
    public Board() {
        for (int i = 1; i <= 9; i++)
        {
            squares.Add(i.ToString());
        }
    }

    public void display() {
        // This could be done more elegantly using loops and if statements
        // especially if something besides 3x3 was ever anticipated.
        Console.WriteLine($"{squares[0]}|{squares[1]}|{squares[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{squares[3]}|{squares[4]}|{squares[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{squares[6]}|{squares[7]}|{squares[8]}");
    }

    public void makeMove(int square, string player) {
        // Convert the 1-based spot number to a 0-based index.
        int index = square - 1;

        // It would be good to include an additional check here to ensure that
        // the spot is available.
        squares[index] = player;
    }

    public bool hasUnclaimedSquares() {
        bool foundDigit = false;

        foreach (string value in squares)
        {
            if (char.IsDigit(value[0]))
            {
                foundDigit = true;
                break;
            }
        }

        return foundDigit;
    }

    public bool isPlayerWinner(string player) {
        // There are more elegant ways to check for a win, especially if
        // something besides a 3x3 squares were anticipated. This brute force
        // approach is sufficient to check for the possibilities.

        bool isWinner = false;

        if ((squares[0] == player && squares[1] == player && squares[2] == player)
            || (squares[3] == player && squares[4] == player && squares[5] == player)
            || (squares[6] == player && squares[7] == player && squares[8] == player)
            || (squares[0] == player && squares[3] == player && squares[6] == player)
            || (squares[1] == player && squares[4] == player && squares[7] == player)
            || (squares[2] == player && squares[5] == player && squares[8] == player)
            || (squares[0] == player && squares[4] == player && squares[8] == player)
            || (squares[2] == player && squares[4] == player && squares[6] == player)
            )
        {
            isWinner = true;
        }

        return isWinner;
    }
}
