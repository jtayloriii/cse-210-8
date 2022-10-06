class Program
{
    static void Main(string[] args)
    {
        points player = new points();
        card card_val = new card();

        while (player_points != 0)
        {
            Console.WriteLine($"The card is: {card_val}");
            Console.WriteLine("Higher/Lower? [h/l]: ");
            string input_ans = Console.ReadLine();

            if (input_ans == "h")
            {
                card new_card = new card();

                if (new_card.number < card_val.number)
                {
                    player_points -= 75;
                }
                if (new_card.number > card_val.number)
                {
                    player_points += 100;
                }

            }

            else if (input_ans == "l")
            {
                card new_card = new card();

                if (new_card.number < card_val.number)
                {
                    player_points -= 75;
                }
                if (new_card.number > card_val.number)
                {
                    player_points += 100;
                }
            }
            else 
            {
                Console.WriteLine("I hate you, go away.");
            }
        }
        
        Console.WriteLine("Good game!");
        Console.WriteLine("Would you like to play again? [y/n] ");
        string play_gen = Console.ReadLine();

        if (play_gen == "y")
        {
            Main();
        }
        else 
        {
            return 0;
        }

        DisplayBoard(board);
        Console.WriteLine("Good game. Thanks for playing!");
    }
}