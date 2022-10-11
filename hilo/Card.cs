class Card {

    string suit;
    public int number;

    public Card(string s, int n) {
        suit = s;
        number = n;
    }

    // Returns a description of the card based on its suit and number
    public string Description() {
        string nameOfCard = number.ToString();
        if (number == 1) {
            nameOfCard = "Ace";
        }
        else if (number == 11) {
            nameOfCard = "Jack";
        }
        else if (number == 12) {
            nameOfCard = "Queen";
        }
        else if (number == 13) {
            nameOfCard = "King";
        }

        return $"{nameOfCard} of {suit}s";
    }
}
