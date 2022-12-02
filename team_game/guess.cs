// Not only is this for the player's guess, but also whether or not they would like
// to continue the game
public class Guess
{
    public string playerGuess() {
        Console.WriteLine("Higher/Lower? [h/l]: ");
        return Console.ReadLine() ?? "";
    }

    public string continueGame() {
        Console.WriteLine("Continue? [y/n]: ");
        return Console.ReadLine() ?? "";
    }
}
