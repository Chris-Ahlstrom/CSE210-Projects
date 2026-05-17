public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public string _userName;
    
    public void Write(string prompt)
    {
        //Console.WriteLine("You have chosen to write an entry.");
        Entry entry = new Entry();
        entry._entryDate = entry.GetDate();
        entry._prompt = prompt;
        Console.WriteLine($"Date: {entry._entryDate} - Prompt: {entry._prompt}");
        entry._response = Console.ReadLine();
        _entries.Add(entry);
        CountTodaysEntries();
    }

    public void Display()
    {
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
        }
    }

    public void Save()
    {
        Console.Write("Would you like to save the journal under your name? (y/n) ");
        string input = Console.ReadLine();
        string fileName = "";
        if (input == "n")
        {
            Console.Write("What file name do would you like to save the journal to? ");
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
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._entryDate}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void Load()
    {
        Console.Write("Would you like to load your journal? (y/n) ");
        string _input = Console.ReadLine();
        string _fileName;
        if (_input == "n")
        {
            Console.Write("What file name do would you like to load the journal from? ");
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
            Entry _entry = new Entry();
            _entry._entryDate = _parts[0];
            _entry._prompt = _parts[1];
            _entry._response = _parts[2];
            _entries.Add(_entry);
        }
    }

    public void CountTodaysEntries()
    {
        int _today = 0;
        DateTime _theCurrentTime = DateTime.Now;
        string _todaysDate = _theCurrentTime.ToShortDateString();
        foreach (Entry entry in _entries)
        {
            if (entry._entryDate == _todaysDate)
            {
               _today++;
            }
        }
        if (_today != 1)
        {
            Console.WriteLine($"You have written {_today} entries today.");
        }
        else
        {
            Console.WriteLine($"You have written {_today} entry today.");
        }
        if (_entries.Count != 1)
        {
            Console.WriteLine($"The current journal has {_entries.Count} entries.");
        }
        else
        {
            Console.WriteLine($"The current journal has {_entries.Count} entry.");
        }
    }
}