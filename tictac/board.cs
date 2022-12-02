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

    }
