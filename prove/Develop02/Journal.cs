public class Journal
{
    public List<Entry> _Entries = new List<Entry>();
    public string _UserName;
    
    public void Write(string prompt)
    {
        //Console.WriteLine("You have chosen to write an entry.");
        Entry entry = new Entry();
        entry._entryDate = entry.GetDate();
        entry._prompt = prompt;
        Console.WriteLine($"Date: {entry._entryDate} - Prompt: {entry._prompt}");
        entry._response = Console.ReadLine();
        _Entries.Add(entry);
        CountTodaysEntries();
    }

    public void Display()
    {
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
        foreach (Entry entry in _Entries)
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
            fileName = _UserName + ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _Entries)
            {
                outputFile.WriteLine($"{entry._entryDate}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void Load()
    {
        Console.Write("Would you like to load your journal? (y/n) ");
        string input = Console.ReadLine();
        string fileName;
        if (input == "n")
        {
            Console.Write("What file name do would you like to load the journal from? ");
            fileName = Console.ReadLine();
            if (!fileName.Contains(".txt"))
            {
                fileName = fileName + ".txt";
            }
        }
        else
        {
            fileName = _UserName + ".txt";
        }
        string[] lines = System.IO.File.ReadAllLines(fileName);
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Entry entry = new Entry();
            entry._entryDate = parts[0];
            entry._prompt = parts[1];
            entry._response = parts[2];
            _Entries.Add(entry);
        }
    }

    public void CountTodaysEntries()
    {
        int today = 0;
        DateTime theCurrentTime = DateTime.Now;
        string todaysDate = theCurrentTime.ToShortDateString();
        foreach (Entry entry in _Entries)
        {
            if (entry._entryDate == todaysDate)
            {
               today++;
            }
        }
        if (today != 1)
        {
            Console.WriteLine($"You have written {today} entries today.");
        }
        else
        {
            Console.WriteLine($"You have written {today} entry today.");
        }
        if (_Entries.Count != 1)
        {
            Console.WriteLine($"The current journal has {_Entries.Count} entries.");
        }
        else
        {
            Console.WriteLine($"The current journal has {_Entries.Count} entry.");
        }
    }
}