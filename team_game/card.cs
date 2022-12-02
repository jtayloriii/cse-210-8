
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
