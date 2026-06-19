using System;

class Program
{
    static void Main(string[] args)
    {
        string[] options = { "Start Game", "Load Game", "Settings", "Quit" };
        int index = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Main Menu ===\n");

            for (int i = 0; i < options.Length; i++)
            {
                if (i == index)
                {
                    //Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"[*]  {options[i]}");
                    Console.ResetColor();
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
                    index = (index == 0) ? options.Length - 1 : index - 1;
                    break;

                case ConsoleKey.DownArrow:
                    index = (index == options.Length - 1) ? 0 : index + 1;
                    break;

                case ConsoleKey.Enter:
                Console.Clear();
                Console.WriteLine($"You selected: {options[index]}");
                //if (options[index] == "Quit")
                {
                    //break;
                }
                Console.ReadKey();
                return;
            }
        }

    }
}