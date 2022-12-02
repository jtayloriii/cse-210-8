
class Program
{
    static void Main(string[] args)
    {
        Card pullCard = new Card();
        Points player1 = new Points(300);
        Guess guess1 = new Guess();

        // Console.WriteLine($"Top card on the deck is: {pullCard.value}");
        // Console.WriteLine($"Points = {player1.player}");
    
        while (player1.player > 0)
        {
            Console.WriteLine();
            var oldCard = pullCard.newCard();
            Console.WriteLine($"The card is: {oldCard}");
            var newGuess = guess1.playerGuess();
            var newCard = pullCard.newCard();
            // Console.WriteLine($"Guess is: {newGuess}");

            if (newGuess == "h")
            {
                if (newCard < oldCard)
                    {
                        player1.player -= 75;
                        Console.WriteLine($"New card was = {newCard}");
                        // Console.WriteLine($"Old card = {oldCard}");
                    }
                if (newCard > oldCard)
                    {
                        player1.player += 100;
                        Console.WriteLine($"New card was = {newCard}");
                        // Console.WriteLine($"Old card = {oldCard}");
                    }
            }
            if (newGuess == "l")
            {
                if (newCard > oldCard)
                    {
                        player1.player -= 75;
                        Console.WriteLine($"New card was = {newCard}");
                        // Console.WriteLine($"Old card = {oldCard}");
                    }
                if (newCard < oldCard)
                    {
                        player1.player += 100;
                        Console.WriteLine($"New card was = {newCard}");
                        // Console.WriteLine($"Old card = {oldCard}");
                    }
            }

        Console.WriteLine($"Your score is = {player1.player}");

        if (player1.player < 0) {
            break;
        }

        var likeContinue = guess1.continueGame();

        if (likeContinue == "y")
            {
                Console.WriteLine($"Got here!");
                continue;
            }
        else 
            {
                Console.WriteLine($"Breaking!");
                break;
            }
        }
    }
}
