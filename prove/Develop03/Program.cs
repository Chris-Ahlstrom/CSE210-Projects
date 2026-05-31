using System;
class Program
{
    static void Main(string[] args)
    {
        List<string> _fileNames = new List<string>{"Alma 7", "1 Nephi 3", "1 Corinthians 10", "Mosiah 2", "John 14"};
        List<string> _verseNumbers = new List<string>{"11-13", "7", "13", "17", "26-27"};
        string response = "";
        do
        {
            Console.Clear();
            DisplayMenu(_fileNames, _verseNumbers);
            int selection = int.Parse(Console.ReadLine());
            Console.WriteLine($"You have selected: {_fileNames[selection - 1]}");
            Reference text = new Reference(_fileNames[selection - 1]);
            text.Run();
            Console.Write("Would you like to memorize another scripture? (y/n) ");
            response = Console.ReadLine();
        } while (response != "n");
        Console.Write("Would you like to learn how to add a scripture of your choice to this memorizer? (y/n) ");
        response = Console.ReadLine();
        if (response == "y")
        {
            LoadInstructions();
        }
        Console.WriteLine("Hope this scripture memorizer helped!");
    }

    public static void DisplayMenu(List<string> Book, List<string> Verses)
    {
        Console.WriteLine("The following scriptures are available to memorize.");
        for (int index = 0; index < Book.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {Book[index]}:{Verses[index]}");
        }
        Console.Write("Which one would you like to memorize today? ");
    }

    public static void LoadInstructions()
    {
        Console.WriteLine();
        string[] _lines = System.IO.File.ReadAllLines("Instructions.txt");
        foreach (string line in _lines)
        {
            Console.WriteLine($"{line}");
        }
        Console.WriteLine();
    }
}