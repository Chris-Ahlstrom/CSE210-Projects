using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        do
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 100);
            int guess;
            int numOfGuesses = 0;
            do
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                guess = int.Parse(userInput);
                if (number < guess)
                {
                    Console.WriteLine("Lower");
                }
                else if (number > guess)
                {
                    Console.WriteLine("Higher");
                }
                numOfGuesses++;
            } while (guess != number);
            if (numOfGuesses == 1)
            {
                Console.WriteLine($"You guessed the number in {numOfGuesses} guess!");
            }
            else
            {
                Console.WriteLine($"You guessed the number in {numOfGuesses} guesses!");
            }
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().ToLower();
        } while (playAgain == "yes");
        
    }
}