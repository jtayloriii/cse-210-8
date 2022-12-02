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
