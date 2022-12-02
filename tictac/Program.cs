// Tictactoe assignment, written by James Taylor


    string[] starting = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};
    List<string> positions = new List<string>(starting);
    
    Console.WriteLine($"{positions[0]} | {positions[1]} | {positions[2]}");
    Console.WriteLine($"{positions[3]} | {positions[4]} | {positions[5]}");
    Console.WriteLine($"{positions[6]} | {positions[7]} | {positions[8]}");

    int input;
    int count = 0;

    while ((gameover(starting) == false) || (count < 9))
    {
        Console.Write("Player 1, input your move: ");
        input = Console.ReadLine();
        positions[input - 1] = "x";

        Console.WriteLine($"{positions[0]} | {positions[1]} | {positions[2]}");
        Console.WriteLine($"{positions[3]} | {positions[4]} | {positions[5]}");
        Console.WriteLine($"{positions[6]} | {positions[7]} | {positions[8]}");

        if (gameover(positions) == true)
        {
            Console.Write("Congrats Player 1!");
            break;
        }

        Console.Write("Player 2, input your move: ");
        input = Console.ReadLine();
        positions[input - 1] = "o";

        Console.WriteLine($"{positions[0]} | {positions[1]} | {positions[2]}");
        Console.WriteLine($"{positions[3]} | {positions[4]} | {positions[5]}");
        Console.WriteLine($"{positions[6]} | {positions[7]} | {positions[8]}");

        count++;
    }
    if (count == 8 && gameover(positions) == false) 
    {
        Console.Write("It's a draw! Good game!");
    }
    else
    {
    Console.Write("Congrats Player 2!");       
    }


bool gameover()
{
    if (positions[0] == positions[1] && positions[1] == positions[2])
    {
        return true;
    }
    else if (positions[3] == positions[4] && positions[4] == positions[5])
    {
        return true;
    }
    else if (positions[6] == positions[7] && positions[7] == positions[8])
    {
        return true;
    }
    else if (positions[0] == positions[3] && positions[3] == positions[6])
    {
        return true;
    }
    else if (positions[1] == positions[4] && positions[4] == positions[7])
    {
        return true;
    }
    else if (positions[2] == positions[5] && positions[5] == positions[8])
    {
        return true;
    }
    else if (positions[0] == positions[4] && positions[4] == positions[8])
    {
        return true;
    }
    else if (positions[2] == positions[4] && positions[4] == positions[6])
    {
        return true;
    }

    return false;
}

main();