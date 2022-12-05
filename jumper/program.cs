class Program
{
    static void Main(string[] args)
    {
        Jumper jumper = new Jumper();
        Word newWord = new Word();
        Answer newAnswer = new Answer();
        Guess newGuess = new Guess();

        Console.WriteLine($"{jumper.first}");
        Console.WriteLine($"{jumper.second}");
        Console.WriteLine($"{jumper.third}");   
        Console.WriteLine($"{jumper.fourth}"); 
        jumper.displayPerson(); 
        Console.WriteLine();

        string word = newWord.getWord();
        Console.WriteLine(word);

        List<string> parsedWord =  new List<string>();
        parsedWord = newAnswer.parseWord(word);
        string displayLine = newAnswer.answerLine(word);
        Console.WriteLine(displayLine);
        Console.WriteLine();

        for (int i = 0; i < 4; i++)
        {
            string userGuess = newGuess.getGuess();

            if (parsedWord.Contains(userGuess))
            {
                int letterIndex = newWord.getIndex(parsedWord, userGuess);
                displayLine = newAnswer.newLine(displayLine, userGuess, letterIndex);
                Console.WriteLine(displayLine);
                Console.WriteLine();
                
                if (displayLine == word) 
                {
                    Console.WriteLine("Congratulations! The jumper lived! Thanks for playing.");
                    Console.WriteLine();
                    break;
                }

                i--;
            }
            else if (!parsedWord.Contains(userGuess))
            {
                Console.WriteLine(displayLine);
                Console.WriteLine();
                newGuess.numWrong += 1;
            }

            if (newGuess.numWrong == 0) 
            {
                Console.WriteLine($"{jumper.first}");
                Console.WriteLine($"{jumper.second}");
                Console.WriteLine($"{jumper.third}");   
                Console.WriteLine($"{jumper.fourth}"); 
                jumper.displayPerson(); 
                Console.WriteLine();
            }

            if (newGuess.numWrong == 1) 
            {
                jumper.oneWrong();
                jumper.displayPerson();
                Console.WriteLine();
            }
            
            if (newGuess.numWrong == 2) 
            {
                jumper.twoWrong();
                jumper.displayPerson();
                Console.WriteLine();
            }

            if (newGuess.numWrong == 3) 
            {
                jumper.threeWrong();
                jumper.displayPerson();
                Console.WriteLine();
            }

            if (newGuess.numWrong == 4) 
            {
                Console.WriteLine();
                jumper.fourWrong();
                Console.WriteLine();
                Console.WriteLine("Looks like our jumper died... You are a terrible person. So long!");
                break;
            }
        }

        // Console.WriteLine(jumper.first);
    }
}