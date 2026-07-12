public class User
{
    private string _userName;
    private string _folderPath;
    private List<Deck> _decks = new List<Deck>();

    public User(string name)
    {
        _userName = name;
        CreateUserFolder();
    }

    public void CreateUserFolder()
    {
        _folderPath = Path.Combine(Directory.GetCurrentDirectory(), _userName + "'s Decks");
        Directory.CreateDirectory(_folderPath);
    }

    public void LoadDecks()
    {
        Console.Write($"Would you like to load the goals in {_userName}.txt? (y/n) ");
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
            _fileName = _userName + ".txt";
        }
        string[] _lines = System.IO.File.ReadAllLines(_fileName);
        foreach (string _line in _lines)
        {
            string[] _parts = _line.Split("|");
        }
    }

     public void SaveDecks()
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
            fileName = _userName + ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Deck deck in _decks)
            {
                outputFile.WriteLine($"");
            }
        }
    }

    public List GetDecks()
    {
        return _decks;
    }
}