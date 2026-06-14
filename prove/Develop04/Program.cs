using System;

class Program
{
    static void Main(string[] args)
    {
        int choice;
            do
            {
                Console.Clear();
                choice = Menu();
                if (choice == 1)
                {
                    Breathe task = new Breathe(choice);
                    task.Breathing();
                }
                else if (choice == 2)
                {
                    Reflect task = new Reflect(choice);
                    task.questionPrompt();
                }
                else if (choice == 3)
                {
                    Listing task = new Listing(choice);
                    task.promptListing();
                }
                else if (choice != 4)
                {
                    Console.WriteLine("Invalid Option.");
                }
            } while (choice > 0 && choice != 4);
            Console.WriteLine("\nHope this mindfulness program helped!!\n");
    }

    public static int Menu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t 1. Start breathing activity");
        Console.WriteLine("\t 2. Start reflecting activity");
        Console.WriteLine("\t 3. Start listing activity");
        Console.WriteLine("\t 4. Quit");
        Console.Write("Select a choice from the menu: ");
        int input = int.Parse(Console.ReadLine());
        return input;
    }
}