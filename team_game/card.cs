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
        string newCard = (cards[index]);
        Console.WriteLine(cards[index]);
    }
    public string Description()   {
        string nameOfCard = newCard;
        if nameOfCard == "1";
    return  $"{nameOfCard}";
    }



}

class player
{

    public player ()  {
        int player = 300;
        int incorrect = 50;
        int correct = 100;




    }

}