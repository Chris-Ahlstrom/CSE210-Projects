using System;

class Program
{
    static void Main(string[] args)
    {
        Journal Book = new Journal();
        PromptGenerator Prompter = new PromptGenerator();
        Prompter.InitializePrompts();
        string userInput = "";
        Console.WriteLine("Welcome to the Journal Program!");
        Console.Write("Please enter your first name: ");
        Book._UserName = Console.ReadLine();
        do
        {
            DisplayMenu();
            userInput = Console.ReadLine();
            Console.WriteLine();
            if (userInput == "1")
            {
                //Console.WriteLine($"The number of prompts in the Prompt Generator is {Prompter._Prompts.Count}");
                string prompt = Prompter.GetPrompt();
                Book.Write(prompt);
                int entryCount = Book._Entries.Count;
            }
            else if (userInput == "2")
            {
                Book.Display();
            }
            else if (userInput == "3")
            {
                Book.Load();
            }
            else if (userInput == "4")
            {
                Book.Save();
            }
        } while (userInput != "5");
    }
    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Please select one of the following choices: ");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.Write("What would you like to do? ");
    }
}