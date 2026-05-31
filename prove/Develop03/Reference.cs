public class Reference
{
    private string _book;
    private List<Verse> _verses = new List<Verse>();
    private string _fileName;

    public Reference(string fileName)
    {
        _fileName = fileName + ".txt";
        string[] name = fileName.Split(" ");
        if (int.TryParse(name[0], out int bookNum))
        {
            _book = bookNum + name[1];
        }
        else
        {
            _book = name[0];
        }
    }
    private void Load()
    {
        string[] _lines = System.IO.File.ReadAllLines(_fileName);
        string text = "";
        int verseNum = 0;
        foreach (string _line in _lines)
        {
            //Console.WriteLine($"{_line}");
            string[] _parts = _line.Split(" ");
            if (!string.IsNullOrWhiteSpace(_line))
            {
                if (int.TryParse(_parts[0], out int num))
                {
                    verseNum = num;
                    foreach (String word in _parts)
                    {
                        text += word + " ";
                    }
                }
                else
                {
                    text += _line;
                }
            }
            else
            {
                Verse verse = new Verse(text, verseNum);
                _verses.Add(verse);
                text = "";
            }
        }
        Verse lastVerse = new Verse(text, verseNum);
        _verses.Add(lastVerse);
        Console.WriteLine();
    }

    public void Display()
    {
        foreach (Verse verse in _verses)
        {
            verse.Display();
            Console.WriteLine();
        }
    }

    public void Prompt()
    {
        string input = "";
        int numOfHiddenVerses = 0;
        int hideThisManyWords = 0;
        Console.Write("Would you like to decide how many words get hidden each time? (y/n) ");
        input = Console.ReadLine();
        if (input == "y")
        {
            Console.Write("How many words do you want hidden each time? ");
            hideThisManyWords = int.Parse(Console.ReadLine());
        }
        do
        {
            Console.Clear();
            List<string> _hiddenText = new List<string>();

            foreach (Verse verse in _verses)
            {
                _hiddenText.Add(verse.Prompt(hideThisManyWords));
            }
            foreach (string text in _hiddenText)
            {
                Console.WriteLine($"{text}\n");
            }
            Console.Write("\n\nPress enter to hide more words or type Q to quit. ");
            input = Console.ReadLine();foreach (Verse verse in _verses)
            {
                if (verse.CheckHiddenStatus())
                {
                    numOfHiddenVerses++;
                }
            }
            if (numOfHiddenVerses == _verses.Count)
            {
                break;
            }
        } while (input != "Q");
    }

    public void Run()
    {
        Load();
        Display();
        Console.Write("-Press enter to hide words-");
        string input = Console.ReadLine();
        Console.WriteLine();
        Prompt();
    }
}