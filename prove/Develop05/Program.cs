using System;
using System.Data.SqlTypes;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        List<string> users = GetUsers();
        List<string> mainMenu = new List<string>{"Create New Goal", "List Goals",
        "Save Goals", "Load Goals", "Record Event", "Quit" };
        string userName;
        int choice = 0;
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
                userName = users[choice];
            }
        }
        else
        {
            users = AddUsers(users);
            userName = users[users.Count - 1];
        }
        User you = new User(userName);
        do
        {
            choice = Menu(mainMenu, "Menu Options:");
            if (choice == 0)
            {
                you.AddGoals(NewGoal());
            }
            else if (choice == 1)
            {
                List<string> GoalNames = you.GetGoals();
                GoalNames.Add("Press enter to continue");
                int goalChoice = Menu(GoalNames, "Your Goals");
            }
            else if (choice == 2)
            {
                you.SaveGoals();
            }
            else if (choice == 3)
            {
                you.LoadGoals();
            }
            else if (choice == 4)
            {
                List<string> GoalNames = you.GetGoals();
                int goalChoice = Menu(GoalNames, "Your Goals");
                you.MarkGoal(goalChoice);
            }
            you.DisplayScore();
        } while (choice != mainMenu.Count - 1);
        Console.WriteLine("Thanks for using the Goal Tracker!");
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

    public static Goal NewGoal()
    {
        List<string> GoalTypes = new List<string>{"Simple Goal", "Eternal Goal", "Checklist Goal"};
        int goalChoice = Menu(GoalTypes, "Select a Goal to Add");
        if (goalChoice == 0)
        {
            string name = "";
            string description = "";
            int points = 0;
            Console.Write("What is the name of your goal? ");
            while (name == "")
            {
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.Write("Please enter a name for the goal. ");
                }
            }
            Console.Write("What is a short description of the goal? ");
            while (description == "")
            {
                description = Console.ReadLine();
                if (description == "")
                {
                    Console.Write("Please enter a description of your goal. ");
                }
            }
            Console.Write("How many points is your goal worth? ");
            while (points <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out int point))
                {
                    Console.Write("Please enter a valid non-negative integer.");
                }
                else
                {
                    if (point < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer.");
                    }
                    else
                    {
                        points = point;
                    }
                }
            }
            SimpleGoal simp = new SimpleGoal(name, description, points);
            return simp;
        }
        else if (goalChoice == 1)
        {
            string name = "";
            string description = "";
            int points = 0;
            Console.Write("What is the name of your goal? ");
            while (name == "")
            {
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.Write("Please enter a name for the goal. ");
                }
            }
            Console.Write("What is a short description of the goal? ");
            while (description == "")
            {
                description = Console.ReadLine();
                if (description == "")
                {
                    Console.Write("Please enter a description of your goal. ");
                }
            }
            Console.Write("How many points is your goal worth? ");
            while (points <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out int point))
                {
                    Console.Write("Please enter a valid non-negative integer.");
                }
                else
                {
                    if (point < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer.");
                    }
                    else
                    {
                        points = point;
                    }
                }
            }
            EternalGoal goal = new EternalGoal(name, description, points);
            return goal;
        }
        else
        {
            string name = "";
            string description = "";
            int points = 0;
            int times = 0;
            int bonus = 0;
            Console.Write("What is the name of your goal? ");
            while (name == "")
            {
                name = Console.ReadLine();
                if (name == "")
                {
                    Console.Write("Please enter a name for the goal. ");
                }
            }
            Console.Write("What is a short description of the goal? ");
            while (description == "")
            {
                description = Console.ReadLine();
                if (description == "")
                {
                    Console.Write("Please enter a description of your goal. ");
                }
            }
            Console.Write("How many points is your goal worth? ");
            while (points <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out int point))
                {
                    Console.Write("Please enter a valid non-negative integer.");
                }
                else
                {
                    if (point < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer.");
                    }
                    else
                    {
                        points = point;
                    }
                }
            }
            Console.Write("How many times would you like to do this goal? ");
            while (times <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out int time))
                {
                    Console.Write("Please enter a valid non-negative integer.");
                }
                else
                {
                    if (time < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer.");
                    }
                    else
                    {
                        times = time;
                    }
                }
            }
            Console.Write("What would you like the bonus to be for completing the goal? ");
            while (bonus <= 0)
            {
                if (!int.TryParse(Console.ReadLine(), out int tempBonus))
                {
                    Console.Write("Please enter a valid non-negative integer.");
                }
                else
                {
                    if (tempBonus < 0)
                    {
                        Console.Write("Please enter a valid non-negative integer.");
                    }
                    else
                    {
                        bonus = tempBonus;
                    }
                }
            }
            Checklist goal = new Checklist(name, description, points, times, bonus);
            return goal;
        }
    }
}