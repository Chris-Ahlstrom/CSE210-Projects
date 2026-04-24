using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string userInput = Console.ReadLine();
        float gradePercent = float.Parse(userInput);

        if (gradePercent >= 90.0)
        {
            if (gradePercent >= 97)
            {
                Console.WriteLine("You got an A+!");
            }
            else if (gradePercent % 10 <= 3)
            {
                Console.WriteLine("You got an A-!");
            }
            else
            {
                Console.WriteLine("You got an A!");
            }
        }
        else if (gradePercent >= 80.0)
        {
            if (gradePercent % 10 >= 7)
            {
                Console.WriteLine("You got an B+.");
            }
            else if (gradePercent % 10 <= 3)
            {
                Console.WriteLine("You got an B-.");
            }
            else
            {
                Console.WriteLine("You got an B.");
            }
        }
        else if (gradePercent >= 70.0)
        {
            if (gradePercent % 10 >= 7)
            {
                Console.WriteLine("You got an C+.");
            }
            else if (gradePercent % 10 <= 3)
            {
                Console.WriteLine("You got an C-.");
            }
            else
            {
                Console.WriteLine("You got an C.");
            }
        }
        else if (gradePercent >= 60.0)
        {
            if (gradePercent % 10 >= 7)
            {
                Console.WriteLine("You got an D+.");
            }
            else if (gradePercent % 10 <= 3)
            {
                Console.WriteLine("You got an D-.");
            }
            else
            {
                Console.WriteLine("You got an D.");
            }
        }
        else 
        {
            if (gradePercent % 10 >= 7)
            {
                Console.WriteLine("You got an F+.");
            }
            else if (gradePercent <= 53)
            {
                Console.WriteLine("You got an F-.");
            }
            else
            {
                Console.WriteLine("You got an F.");
            }
        }

        if(gradePercent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Unfortunately, you failed the class.");
        }
    }
}