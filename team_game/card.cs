class card
{
    List<string> cards = new List<string>();
    public card() {
        for (int i = 1; i <= 13; i += 1)
        {
            cards.Add(i.ToString());
        }
    var random = new Random();
        int index = random.Next(cards.Count);
        Console.WriteLine(cards[index]);
    }
}

class points
{
    
    int player = 300;
    int incorrect = 50;
    int correct = 100;


}