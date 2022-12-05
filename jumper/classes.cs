class Jumper // Really just displaying the current "state" of our jumping friend...
{

    public string first =  "    ___";
    public string second = "  /_____\\";
    public string third =  "  \\     / ";
    public string fourth = "   \\   /  ";

    public void oneWrong() 
    {
        Console.WriteLine($"{second}");
        Console.WriteLine($"{third}");   
        Console.WriteLine($"{fourth}");     
    }

    public void twoWrong() 
    {
        Console.WriteLine($"{third}");   
        Console.WriteLine($"{fourth}");           
    }

    public void threeWrong() 
    { 
        Console.WriteLine($"{fourth}");           
    }

    public void fourWrong() 
    {
        string first =  "     X";
        string second = "    /|\\";
        string third =  "    / \\";   
        string fourth = "^^^^^^^^^^^^";
        Console.WriteLine($"{first}");
        Console.WriteLine($"{second}");
        Console.WriteLine($"{third}");   
        Console.WriteLine($"{fourth}");  
    }

    public void displayPerson() 
    {
        string first =  "     O";
        string second = "    /|\\";
        string third =  "    / \\";
        Console.WriteLine($"{first}");
        Console.WriteLine($"{second}");
        Console.WriteLine($"{third}");
    }
}

class Word // things regarding the correct/key word for the game
{
    public string getWord() 
    {
        List<string> words = new List<string> {"heart", "vigor", "power", "might", "love", "force"};
        Random rnd = new Random();
        int rndIndex = rnd.Next(words.Count);

        return words[rndIndex];
    }

    public int getIndex(List<string> inList, string guess)
    {
        int index = inList.FindIndex(a => a.Contains(guess));
        return index;
    }


}

class Answer // showing the correct guess and the guess display line, not the original word
{
    public List<string> parseWord(string word)
    {
        List<string> parsedWord =  new List<string>();
        foreach (char c in word) 
        {
            string s = c.ToString();
            parsedWord.Add(s);
        }
        return parsedWord;
    }

    public string answerLine(string word) // (add: "char guess")
    {
        string answer = "";
        for (int i = 0; i < word.Length; i++)
        {
            answer = answer + "_";
        }
        return answer;
    }

    public string newLine(string line, string guess, int index)
    {
        char[] changeArray = line.ToCharArray();
        changeArray[index] = char.Parse(guess); // index starts at 0!
        string newLine = new string (changeArray);

        return newLine;
    }
}

class Guess // getting the guess and keeping track of how many they got right/wrong
{
    public int guessNum = 0;
    public int numRight = 0;
    public int numWrong = 0;
    public string getGuess()
    {
        Console.WriteLine("Please make your guess: ");

        string? guess1 = Console.ReadLine();
        if (guess1 is null) 
        {
            return "";
        }
        return guess1;
    }
}
