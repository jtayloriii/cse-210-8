class Board {

    List<string> spaces = new List<string>();

    public Board() {
        for (int i = 1; i <= 9; i += 1)
        {
            spaces.Add(i.ToString());
        }
    }


    public void print() {
        Console.WriteLine($"{spaces[0]}|{spaces[1]}|{spaces[2]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{spaces[3]}|{spaces[4]}|{spaces[5]}");
        Console.WriteLine("-+-+-");
        Console.WriteLine($"{spaces[6]}|{spaces[7]}|{spaces[8]}");
    }

    public void move(int index, string player) {
        spaces[index] = player;
    }

    public bool isWinner(string player) {

        bool wonGame = false;

        if ((spaces[0] == player && spaces[1] == player && spaces[2] == player)
            || (spaces[3] == player && spaces[4] == player && spaces[5] == player)
            || (spaces[6] == player && spaces[7] == player && spaces[8] == player)
            || (spaces[0] == player && spaces[3] == player && spaces[6] == player)
            || (spaces[1] == player && spaces[4] == player && spaces[7] == player)
            || (spaces[2] == player && spaces[5] == player && spaces[8] == player)
            || (spaces[0] == player && spaces[4] == player && spaces[8] == player)
            || (spaces[2] == player && spaces[4] == player && spaces[6] == player)
            )
        {
            wonGame = true;
        }

        return wonGame;
    }
}




class Player {
    public int getMove1() {
        Console.WriteLine("Player 1, input your move: ");

        string? input1 = Console.ReadLine();
        if (input1 is null) {
            return 0;
        }

        int input = int.Parse(input1);
        input -= 1;

        return input;
    }

        public int getMove2() {
        Console.WriteLine("Player 2, input your move: ");

        string? input1 = Console.ReadLine();
        if (input1 is null) {
            return 0;
        }
        int input = int.Parse(input1);
        input -= 1;

        return input;
    }
}