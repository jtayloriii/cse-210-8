class Program
{
    static void Main(string[] args)
    {
        Board gameBoard = new Board();
        Player newPlay = new Player();

        string player1 = "x";
        string player2 = "o";


        gameBoard.print();
        Console.WriteLine(); 
        int playerMove = newPlay.getMove1();
        gameBoard.move(playerMove, player1);
        Console.WriteLine(); 


        for (int i = 1; i <= 4; i++)
        {
            gameBoard.print();
            Console.WriteLine(); 
            playerMove = newPlay.getMove2();

            gameBoard.move(playerMove, player2);
            Console.WriteLine(); 
            gameBoard.print();

            if (gameBoard.isWinner(player2) == true) 
            {
                Console.WriteLine("Player 2 wins! Thanks for playing!");
                break;
            }

            Console.WriteLine();            
                    
            playerMove = newPlay.getMove1();
            Console.WriteLine(); 

            gameBoard.move(playerMove, player1);
            gameBoard.print();
            Console.WriteLine(); 

            if (gameBoard.isWinner(player1) == true) 
            {
                Console.WriteLine("Player 1 wins! Thanks for playing!");
                break;
            }

            Console.WriteLine();
        }

        if ((gameBoard.isWinner(player2) == false) && (gameBoard.isWinner(player1) == false)) 
        {
            Console.WriteLine("It's a tie! Thanks for playing!");
        }
    }
}