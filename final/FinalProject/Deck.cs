public class Deck
{
    private List<Card> _decklist = new List<Card>();
    private string _deckName;
    private string _format;
    private bool _isCommanderDeck = false;
    private bool _hasCommander = false;
    private string _folderPath;
    private string _fileName;
    private string _filePath;
    private List<string> _cardTypes = new List<string>{"Land", "Creature", "Artifact", "Enchantment", "Planeswalker", "Instant", "Sorcery", "Battle"};
    private string _cardMenu = "Select a Card to Add";
    private List<string> _deckMainMenu = new List<string>{"Add a Card", "Remove a Card", "View Cards", "Save Deck", "View Deck Stats", "Quit"};
    private string _deckMenuName = "Deck Options";
    private List<string> _cardNames = new List<string>();
    private int _landCount = 0;
    private int _totalManaCost;
    private int _totalCards;
    private List<int> _numOfEachManaCost = new List<int>{0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};

    public Deck(string folderPath)
    {
        _folderPath = folderPath;
        Console.WriteLine("What would you like to call this deck?");
        _deckName = Console.ReadLine();
        CreateDeckFile();
        Console.Write("What format is this deck for? ");
        string answer = Console.ReadLine();
        if (answer == "Commander" || answer == "commander" || answer == "Brawl" || answer == "Brawl")
        {
            _isCommanderDeck = true;
        }
        RunDeck();
    }

    public Deck(string folderPath, string Name)
    {
        _deckName = Name;
        _folderPath = folderPath;
        CreateDeckFile();
        LoadCards();
    }

    public void RunDeck()
    {
        int choice;
        do
        {
            choice = DeckMenu(_deckMainMenu, _deckMenuName);
            switch (choice)
            {
                case 0: // Add Card
                    int cardChoice = DeckMenu(_cardTypes, _cardMenu);
                    AddCards(cardChoice);
                    break;

                case 1: // Remove a Card
                    if (_decklist.Count != 0)
                    {
                        if (_cardNames.Count == 0)
                        {
                            GetCardNames();
                        }
                        List<int> copyData = GetCopyData();
                        int cardIndex = DisplayCards(_cardNames, copyData, "Select a Card to Remove", 10, true);
                        RemoveCard(cardIndex);
                    }
                    else
                    {
                        Console.WriteLine("There are no cards in this deck.");
                        Thread.Sleep(500);
                    }
                    break;
                
                case 2: // View the Cards in the deck
                    if (_decklist.Count != 0)
                    {
                        if (_cardNames.Count == 0)
                        {
                            GetCardNames();
                        }
                        List<int> copyData = GetCopyData();
                        int doNotUse = DisplayCards(_cardNames, copyData, "Deck list for " + _deckName, 10, false);
                    }
                    else
                    {
                        Console.WriteLine("There are no cards in this deck.");
                        Thread.Sleep(500);
                    }
                    break;
                
                case 3: // Save the Deck
                    if (_decklist.Count != 0)
                    {
                        SaveCards();
                    }
                    else
                    {
                        Console.WriteLine("There are no cards in this deck.");
                        Thread.Sleep(500);
                    }
                    break;
                case 4: // List Deck stats
                    if(_decklist.Count != 0)
                    {
                        ListDeckStats();
                    }
                    else
                    {
                        Console.WriteLine("There are no cards in this deck.");
                    }
                    Thread.Sleep(500);
                    break;

                case 5: // Quit
                    Console.WriteLine("Returning to deck selection...");
                    Thread.Sleep(500);
                    break;

                default:
                    Console.WriteLine("Option not yet implemented.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
        } while (choice != _deckMainMenu.Count - 1);
    }

    public void CreateDeckFile()
    {
        Directory.CreateDirectory(_folderPath);
        _fileName = _deckName + ".txt";
        _filePath = Path.Combine(_folderPath, _fileName);
    }
    
    public void LoadCards()
    {
        _decklist.Clear();
        Dictionary<string, string> data = new Dictionary<string, string>();
        Card currentCard = null;
        foreach (string line in File.ReadLines(_filePath))
        {
            string trimmed = line.Trim();

            if (trimmed == "Card:")
            {
                if (data.Count > 0)
                {
                    _decklist.Add(CardFactory.Create(data));
                    data.Clear();
                }
                continue;
            }

            if (string.IsNullOrWhiteSpace(trimmed))
            {
                continue;
            }

            int idx = trimmed.IndexOf('=');
            string key = trimmed[..idx];
            string value = trimmed[(idx + 1)..];

            data[key] = value;
        }

        if (data.Count > 0)
        {
            _decklist.Add(CardFactory.Create(data));
        }
    }


    public void SaveCards()
    {
        using (StreamWriter writer = new StreamWriter(_filePath))
        {
            foreach (var card in _decklist)
            {
                writer.WriteLine("Card:");
                writer.WriteLine($"Name={card.Name}");
                writer.WriteLine($"ManaCost={card.ManaCost}");
                writer.WriteLine($"CardType={card.CardType}");
                writer.WriteLine($"IsLand={card.IsLand}");
                writer.WriteLine($"IsCommander={card.IsCommander}");
                writer.WriteLine($"IsPermanent={card.IsPermanent}");
                writer.WriteLine($"IsLegendary={card.IsLegendary}");
                writer.WriteLine($"ManaValue={card.ManaValue}");
                writer.WriteLine($"Copies={card.Copies}");
                writer.WriteLine($"Colors={string.Join(";", card.Colors)}");
                writer.WriteLine($"Abilities={string.Join(";", card.Abilities)}");
                writer.WriteLine($"Subtypes={string.Join(";", card.Subtypes)}");
                writer.WriteLine($"Effects={string.Join(";", card.Effects)}");
                writer.WriteLine();
            }
        }
    }


    public void AddCards(int choice)
    {
        switch (choice)
        {
            case 0:
                Land land = new Land();
                land.PromptForCopies();
                _decklist.Add(land);
                break;

            case 1:
                Creature creature = new Creature(_hasCommander);
                creature.PromptForCopies();
                _decklist.Add(creature);
                if (creature.CheckCommanderStatus())
                {
                    _hasCommander = true;
                }
                break;

            case 2:
                Artifact artifact = new Artifact();
                artifact.PromptForCopies();
                _decklist.Add(artifact);
                break;

            case 3:
                Enchantment enchantment = new Enchantment();
                enchantment.PromptForCopies();
                _decklist.Add(enchantment);
                break;

            case 4:
                Planeswalker planeswalker = new Planeswalker();
                planeswalker.PromptForCopies();
                _decklist.Add(planeswalker);
                break;

            case 5:
                Instant instant = new Instant();
                instant.PromptForCopies();
                _decklist.Add(instant);
                break;

            case 6:
                Sorcery sorcery = new Sorcery();
                sorcery.PromptForCopies();
                _decklist.Add(sorcery);
                break;

            case 7:
                Battle battle = new Battle();
                battle.PromptForCopies();
                _decklist.Add(battle);
                break;
        }
    }

    public void RemoveCard(int cardIndex)
    {
        if (_decklist[cardIndex].Copies == 1)
        {
            _decklist.RemoveAt(cardIndex);
        }
        else
        {
            Console.Write($"This deck currently has {_decklist[cardIndex].Copies} of {_decklist[cardIndex].Name}. How many do you want to remove? ");
            int copiesToRemove = 0;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out copiesToRemove))
                {
                    Console.Write("Please enter a valid non-negative integer. ");
                }
                else
                {
                    if (copiesToRemove <= 0)
                    {
                        Console.Write("Please enter a valid non-negative integer. ");
                    }
                }
            }while (copiesToRemove <= 0);
            if (_decklist[cardIndex].Copies == copiesToRemove)
            {
                _decklist.RemoveAt(cardIndex);
            }
            else
            {
                _decklist[cardIndex].SetCopies(_decklist[cardIndex].Copies - copiesToRemove);
            }
        }
    }

    public void GetCardNames()
    {
        foreach (Card card in _decklist)
        {
            _cardNames.Add(card.Name);
        }
    }

    public List<int> GetCopyData()
    {
        List<int> copyData = new List<int>();
        foreach (Card card in _decklist)
        {
            copyData.Add(card.Copies);
        }
        return copyData;
    }
    
    public void ColorChecker()
    {}

    public static int DeckMenu(List<string> options, string menuTitle)
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

    public static int DisplayCards(List<string> cards, List<int> copyData, string header, int pageSize, bool edit)
    {
        int index = 0;
        int page = 0;
        bool ended = false;
        while (!ended)
        {
            Console.Clear();
            Console.WriteLine($"=== {header} ===\n");
            Console.WriteLine($"{"Name",-30}{"Copies",3}");
            int start = page * pageSize;
            int end = Math.Min(start + pageSize, cards.Count);

            for (int i = start; i < end; i++)
            {
                if ((i == start + index) && edit)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"{cards[i],-30}{copyData[i],3}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{cards[i],-30}{copyData[i],3}");
                }
            }

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    index = (index == 0) ? end - start - 1 : index - 1;
                    break;

                case ConsoleKey.DownArrow:
                    index = (index == end - start - 1) ? 0 : index + 1;
                    break;
                
                case ConsoleKey.RightArrow:
                    if ((page + 1) * pageSize < cards.Count)
                    {
                        page++;
                        index = 0;
                    }
                    break;

                case ConsoleKey.LeftArrow:
                    if (page > 0)
                    {
                        page--;
                        index = 0;
                    }
                    break;

                case ConsoleKey.Enter:
                    ended = true;
                    Console.Clear();
                    break;
            }
        }
        return index;
    }

    public string GetDeckName()
    {
        return _deckName;
    }

    public void GetLandCount()
    {
        foreach (Card card in _decklist)
        {
            if (card.CheckIfLand())
            {
                _landCount += card.Copies;
            }
        }
    }

    public void GetTotalManaCost()
    {
        foreach (Card card in _decklist)
        {
            card.CostConverter();
            _totalManaCost += card.GetManaValue();
        }
    }

    public void GetManaValueTotals()
    {
        foreach (Card card in _decklist)
        {
            if (!card.CheckIfLand())
            {
                _numOfEachManaCost[card.ManaValue]++;
            }
        }
    }

    public void GetTotalCards()
    {
        foreach (Card card in _decklist)
        {
            _totalCards += card.Copies;
        }
    }

    public void ListDeckStats()
    {
        GetLandCount();
        GetTotalCards();
        GetTotalManaCost();
        GetManaValueTotals();
        Console.WriteLine($"This deck has {_landCount} lands.");
        Console.WriteLine($"The average mana value of this deck is {(float)_totalManaCost / (float)(_totalCards)} mana with lands and {(float)_totalManaCost / ((float)_totalCards - (float)_landCount)} mana without lands.");
        Console.WriteLine($"Your mana curve is:");
        for(int index = 0; index < _numOfEachManaCost.Count; index++)
        {
            Console.WriteLine($"{_numOfEachManaCost[index]} {index}-mana spells.");
        }
        Console.WriteLine("Press any key to continue.");
        Console.ReadLine();
    }
}