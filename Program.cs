class Hangman
{
    static void Main()
    {
        //  Word list
        string[] words = { "dance", "art", "drawing", "singing", "sport","swimming","games" };

        //  Pick a random word
        Random random = new Random();
        //length of secret word
        string secretWord = words[random.Next(words.Length)];
        //converting secret word into char array
        char[] secretChars = secretWord.ToCharArray();

        //  Create display array with underscores
        char[] display = new char[secretWord.Length];
        //looping through display array and filling it with underscores
        for (int i = 0; i < display.Length; i++)
        {
            display[i] = '_';
        }

        //  Tracking variables
        int maxGuesses = 10;
        int guessesUsed = 0;
        string wrongLetters = "";
        string guessedLetters = "";

        // Game loop
        while (guessesUsed < maxGuesses && new string(display) != secretWord)
        {
            Console.WriteLine("Word : " + new string(display));
            Console.WriteLine("Wrong Letters : " + wrongLetters);
            Console.WriteLine("Remaining Guessess :" + (maxGuesses - guessesUsed));
            Console.WriteLine("Enter a letter or guess a whole word");
            Console.WriteLine("Clue is " + "'Hobbies'");

            //Guessing a letter
            string input = Console.ReadLine().ToLower();
            if (input.Length == 1)
            {
                char guess = input[0];
                if (guessedLetters.Contains(guess))
                {

                    Console.WriteLine("You already guessed the letter");

                }
                else if (secretWord.Contains(guess))
                {
                    for (int i = 0; i < secretChars.Length; i++)
                    {
                        if (secretChars[i] == guess)
                        {
                            display[i] = guess;
                        }
                    }
                    guessedLetters += guess;
                }
                else
                {
                    wrongLetters += guess + " ";
                    guessedLetters += guess;
                    guessesUsed++;
                }
            }
            else
            {
                if (input == secretWord)
                {
                    display = secretChars;
                }
                else
                {
                    Console.WriteLine("Wrong guess");
                    guessesUsed++;
                }
            }

            //Game result
            if (new string(display) == secretWord)
            {
                Console.WriteLine("Congratulations! You guessed the word: " + secretWord);
            }
            else if (guessesUsed >= maxGuesses)
            {
                Console.WriteLine("Game Over! The word was: " + secretWord);


            }


        }
    }
}
    
