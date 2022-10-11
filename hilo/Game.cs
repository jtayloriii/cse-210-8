class Game {

    Player player = new Player();

    Score score = new Score(300);

    Deck deck = new Deck();

    Card CurrentCard;

    public Game() {
        CurrentCard = deck.DrawRandomCard();
    }

    public void Play() {

        var keepPlaying = true;
        while (keepPlaying) {

            Console.WriteLine("");
            Console.WriteLine($"The card is: {CurrentCard.number}");

            var nextCard = deck.DrawRandomCard();
            var guess = player.Guess();

            if (guess == "h") {
                if (nextCard.number > CurrentCard.number) {
                    score.CurrentScore += 100;
                } else {
                    score.CurrentScore -= 75;
                }

            } else if (guess == "l") {
                if (nextCard.number < CurrentCard.number) {
                    score.CurrentScore += 100;
                } else {
                    score.CurrentScore -= 75;
                }
            }

            Console.WriteLine($"Next card was: {nextCard.number}");
            Console.WriteLine($"Yours score is: {score.CurrentScore}");
            CurrentCard = nextCard;

            keepPlaying = player.KeepPlaying();            
        }
    }
}
