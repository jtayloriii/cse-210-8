// these are for finding a new card, but they don't create a full deck as that
// isn't a requirement...
public class Card
{
    public int value;

    public Card() {
        value = newCard();
    }

    public int newCard() {
        Random ranCard = new Random();
        int randomCard = ranCard.Next(1, 13);
        return randomCard;
    }
}
