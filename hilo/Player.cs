class Player {

    public string Guess() {
        Console.Write("Higher or lower? (h/l)");
        return Console.ReadLine() ?? "";
    }
    public bool KeepPlaying() {
        Console.Write("Keep Playing? (y/n)");
        string response = Console.ReadLine() ?? "";
        return response == "y";
    }
}
