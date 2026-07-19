using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        int choice;
        string userName;
        bool run = true;
        List<string> booleanAnswers = new List<string>{"Yes", "No"};
        string booleanMenu = "Would you like to quit?";
        List<string> users = GetUsers();
        do
        {
            if (users.Count != 0)
            {
                users.Add("New User");
                Console.WriteLine("Please select a user:");
                choice = Menu(users, "Users");
                Console.Clear();
                if (choice == users.Count - 1)
                {
                    users.RemoveAt(users.Count - 1);
                    users = AddUsers(users);
                    userName = users[users.Count - 1];
                }
                else
                {
                    users.RemoveAt(users.Count - 1);
                    userName = users[choice];
                }
            }
            else
            {
                users = AddUsers(users);
                userName = users[users.Count - 1];
            }
            User you = new User(userName);
            choice = Menu(booleanAnswers, booleanMenu);
            if ( choice == 0)
            {
                run = false;
            }
        } while (run);
        Console.WriteLine("Thanks for using this Magic: The Gathering decklist storage and analysis program!");
    }

    public static int Menu(List<string> options, string menuTitle)
    {
        int index = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine($"=== {menuTitle} ===\n");

            for (int i = 0; i < options.Count; i++)
            {
                if (i == index)
                {
                    Console.WriteLine($"[*]  {options[i]}");
                }
                else
                {
                    Console.WriteLine($"[ ]  {options[i]}");
                }
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    index = (index == 0) ? options.Count - 1 : index - 1;
                    break;

                case ConsoleKey.DownArrow:
                    index = (index == options.Count - 1) ? 0 : index + 1;
                    break;

                case ConsoleKey.Enter:
                    Console.Clear();
                    return index;
            }
        }
    }

    public static List<string> GetUsers()
    {
        List<string> names = new List<string>();
        string[] _lines = System.IO.File.ReadAllLines("users.txt");
        foreach (string line in _lines)
        {
            names.Add(line);
        }
        return names;
    }

    public static List<string> AddUsers(List<string> users)
    {
        Console.Write("Enter a username: ");
        string name = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter("users.txt"))
        {
            foreach (string user in users)
            {
                outputFile.WriteLine($"{user}");
            }
            outputFile.WriteLine($"{name}");
        }
        users.Add(name);
        return users;
    }

}