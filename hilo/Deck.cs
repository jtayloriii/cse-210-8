// Represents a full deck of cards
class Deck {

    // The 4 different valid suits in a 52 deck of cards
    List<string> suits = new List<string> { "heart", "diamond", "spade", "club" };

    int cardCountPerSuit = 13;

    // Used for getting random cards from the deck
    Random generator = new Random();

    public List<Card> Cards = new List<Card>();

    public Deck() {
        BuildDeck();
    }

    void BuildDeck() {
        // Do not build the cards if there are already cards in the deck
        if (Cards.Count != 0) { 
            return;
        }

        // This loop creates 13 cards for each suit, which will result in 52 total cards
        foreach (var suit in suits) {
            for (int i = 1; i <= cardCountPerSuit; i++) {
                Card card = new Card(suit, i);
                Cards.Add(card);
            }
        }
    }

    // Draws a random card and removes it from the deck
    public Card DrawRandomCard() {
        int randomIndex = generator.Next(Cards.Count);
        Card randomCard = Cards[randomIndex];
        Cards.RemoveAt(randomIndex);
        return randomCard;
    }

    public bool HasMoreCards() {
        return Cards.Count > 0;
    }
}
