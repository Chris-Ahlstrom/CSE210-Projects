public class Deck
{
    private List<Card> _decklist = new List<Card>();
    private string _deckName;
    private string _format;
    private bool _isCommanderDeck = false;

    public Deck()
    {
        Console.WriteLine("What would you like to call this deck");
    }
    
    public void LoadCards()
    {
        Console.Write($"Would you like to load the goals in {_deckName}.txt? (y/n) ");
        string _input = Console.ReadLine();
        string _fileName;
        if (_input == "n")
        {
            Console.Write("What file name do would you like to load goals from? ");
            _fileName = Console.ReadLine();
            if (!_fileName.Contains(".txt"))
            {
                _fileName = _fileName + ".txt";
            }
        }
        else
        {
            _fileName = _deckName + ".txt";
        }
        string[] _lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string _line in _lines)
        {
            string[] _parts = _line.Split("|");
        }
    }

    public void SaveCards()
    {
        Console.Write("Would you like to save the journal under your name? (y/n) ");
        string input = Console.ReadLine();
        string fileName = "";
        if (input == "n")
        {
            Console.Write("What file name would you like to save your goals under? ");
            fileName = Console.ReadLine();
            if (!fileName.Contains(".txt"))
            {
                fileName = fileName + ".txt";
            }
        }
        else
        {
            fileName = _deckName + ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Card card in _decklist)
            {
                outputFile.WriteLine($"");
            }
        }
    }

    public void AddCards(int choice)
    {
        switch (choice)
        {
            case 1:
            Land card1 = new Land();
            if (card1.CheckBasic())
            {
                int copiesToAdd = 0;
                Console.Write("How many copies of this basic land would you like to add? ");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out copiesToAdd))
                    {
                        Console.Write("Please enter a valid non-negative integer. ");
                    }
                    else
                    {
                        if (copiesToAdd <= 0)
                        {
                           Console.Write("Please enter a valid non-negative integer. ") ;
                        }
                    }
                }while (copiesToAdd <= 0);
                for (int added = 0; added < copiesToAdd; added++)
                {
                    _decklist.Add(card1);
                }
            }
            else if (_isCommanderDeck == false)
            {
                int copiesToAdd = 0;
                Console.Write("How many copies of this land would you like to add? ");
                do
                {
                    if (!int.TryParse(Console.ReadLine(), out copiesToAdd))
                    {
                        Console.Write("Please enter a valid non-negative integer. ");
                    }
                    else
                    {
                        if (copiesToAdd <= 0)
                        {
                           Console.Write("Please enter a valid non-negative integer. ");
                        }
                    }
                }while (copiesToAdd <= 0);
                for (int added = 0; added < copiesToAdd; added++)
                {
                    _decklist.Add(card1);
                }
            }
            else
            {
                _decklist.Add(card1);
            }
            break;

            case 2:
            Creature card2 = new Creature();
            _decklist.Add(card2);
            break;

            case 3:
            Artifact card3 = new Artifact();
            _decklist.Add(card3);
            break;

            case 4:
            Enchantment card4 = new Enchantment();
            _decklist.Add(card4);
            break;

            case 5:
            Planeswalker card5 = new Planeswalker();
            _decklist.Add(card5);
            break;

            case 6:
            Instant card6 = new Instant();
            _decklist.Add(card6);
            break;

            case 7:
            Sorcery card7 = new Sorcery();
            _decklist.Add(card7);
            break;

            case 8:
            Battle card8 = new Battle();
            _decklist.Add(card8);
            break;
        }
    }

    public void ListDeckStats()
    {}

    public void DisplayDeckList()
    {}

    public void ColorChecker()
    {}
}