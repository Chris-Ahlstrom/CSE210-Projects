public class Verse
{
    private List<Word> _Words = new List<Word>();
    private string _text;
    private int _verseNum;
    private bool _allTextIsHidden;
    private List<int> _hiddenWordNumbers = new List<int>();

    public Verse(string text, int verseNum)
    {
        _text = text;
        _verseNum = verseNum;
        _allTextIsHidden = false;
        CreateWords();
    }

    private void CreateWords()
    {
        List<string> words = _text.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).ToList();
        foreach (string word in words)
        {
            Word word1 = new Word(word);
            _Words.Add(word1);
        }
    }

    public void Display()
    {
        for (int wordNum = 0; wordNum < _Words.Count; wordNum++)
        {
            if ((wordNum + 1) % 15 == 0)
            {
                Console.Write($"{_Words[wordNum].GetWord()}\n");
            }
            else
            {
                Console.Write($"{_Words[wordNum].GetWord()} ");
            }
        }
        Console.WriteLine();
    }

    public string Prompt(int hideThisManyWords)
    {
        int hiddenWordTotal = 0;
        string hiddenText = "";
        Random rnd = new Random();
        int wordsToHide;
        if (hideThisManyWords != 0)
        {
            wordsToHide = hideThisManyWords;
        }
        else
        {
            wordsToHide = rnd.Next(1, 5);
        }
        if (wordsToHide > (_Words.Count - hiddenWordTotal - 1)) //This logic prevents the program from trying to hide more words than are in the verse
        {
            wordsToHide = _Words.Count - hiddenWordTotal - 1;
        }
        int wordToHide;
        do //This loop hides words and sets the bool _isHidden on each to True
        {
            do //This loop randomly selects which words to hide and ensures that only unhidden words can be hidden
            {
                wordToHide = rnd.Next(0, _Words.Count);
            } while (_hiddenWordNumbers.Contains(wordToHide));

            if (!_Words[wordToHide].CheckIfHidden() && !int.TryParse(_Words[wordToHide].GetWord(), out int vNum))
            { //This logic checks if the word isn't hidden or is the verse number
                _Words[wordToHide].SetAsHidden();
                _hiddenWordNumbers.Add(wordToHide);
                hiddenWordTotal++;
            }
            wordsToHide--;
        } while ((wordsToHide > 0) && (_hiddenWordNumbers.Count <= _Words.Count));

        foreach (Word word in _Words)
        { //This loop adds the word to the output string along with newline characters to increase legibility 
            int wordNum = _Words.IndexOf(word);
            if (word.CheckIfHidden())
            {
                    hiddenText += word.GetHiddenWord() + " ";
                    if ((wordNum + 1) % 15 == 0)
                    {
                        hiddenText += "\n";
                    }  
            }
            else
            {
                hiddenText += word.GetWord() + " ";
                if ((wordNum + 1) % 15 == 0)
                {
                    hiddenText += "\n";
                }
            }
        }
        if (_hiddenWordNumbers.Count == _Words.Count - 1)
        {
            _allTextIsHidden = true;
        }
        return hiddenText;
    }

    public bool CheckHiddenStatus()
    {
        return _allTextIsHidden;
    }
}