public class User
{
    private string _userName;
    private string _folderPath;
    private string _folderName;
    private List<Deck> _decks = new List<Deck>();
    private List<string> _deckNames = new List<string>();
    private List<string> _userMenuOptions = new List<string>{"Add Deck", "Display Decks", "Load Decks", "Edit Deck", "Quit"};
    private string _userMenuName = "User Options";

    public User(string name)
    {
        _userName = name;
        CreateUserFolder();
        int choice;
        do
        {
            choice = UserMenu(_userMenuOptions, _userMenuName);
            switch (choice)
            {
                case 0:
                    AddDeck();
                    break;

                case 1:
                    if (_deckNames.Count != 0)
                    {
                        DisplayDecks();
                    }
                    else
                    {
                        Console.Write("Please load decks before displaying them.");
                        Thread.Sleep(2000);
                    }
                    break;

                case 2:
                    LoadDecks();
                    Console.WriteLine("Decks Loaded. Press enter to return to the menu and the select 'Edit Deck' to choose a deck to edit.");
                    Console.ReadLine();
                    break;

                case 3:
                    int deckChoice = UserMenu(_deckNames, "Choose a deck to edit");
                    Deck deck = new Deck(_folderPath, _deckNames[deckChoice]);
                    deck.RunDeck();
                    break;
                
                case 4:
                    Console.Write($"Returning to user selection...");
                    Thread.Sleep(1500);
                    break;
            }
        } while(choice != _userMenuOptions.Count - 1);
    }

    public void CreateUserFolder()
    {
        _folderName = _userName + "'s Decks";
        _folderPath = Path.Combine(Directory.GetCurrentDirectory(), _folderName) ;
        Directory.CreateDirectory(_folderPath);
    }

    public void LoadDecks()
    {
        string[] deckFiles = Directory.GetFiles(_folderPath, "*.txt");
        foreach (string fileName in deckFiles)
        {
            _deckNames.Add(Path.GetFileNameWithoutExtension(fileName));
        }
    }

    public void GetDeckNames()
    {
        foreach (Deck deck in _decks)
        {
            _deckNames.Add(deck.GetDeckName());
        }
    }

    public void AddDeck()
    {
        Deck deck = new Deck(_folderName);
        _decks.Add(deck);
    }

    public static int UserMenu(List<string> options, string menuTitle)
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

    public void DisplayDecks()
    {
        Console.WriteLine($"{_userName}'s Decks");
        foreach (string name in _deckNames)
        {
            Console.WriteLine($" - {name}");
        }
    }
}