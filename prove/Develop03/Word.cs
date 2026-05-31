public class Word
{
    private string _word;
    private string _hiddenWord = "";
    private bool _isHidden;
    private List<string> _punctuation = new List<string>{".", ",", "'", "?", "!", ";", ":", "(", ")", "-"};
    private bool _containsPunctuation;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
        _containsPunctuation = false;
        CheckForPunctuation();
    }
    
    private void CheckForPunctuation()
    {
        foreach (string mark in _punctuation)
        {
            for (int i = 0; i <_word.Length; i++)
            {
                if (mark[0] == _word[i])
                {
                    _containsPunctuation = true;
                }
            }
        }
    }

    public string GetWord()
    {
        return _word;
    }

    private void GenerateHiddenWordWithPunctuation()
    {

        _hiddenWord = "";
        string charToAdd = "";
        for (int i = 0; i < _word.Length; i++)
        {
            charToAdd = "";
            foreach (string mark in _punctuation)
            {
                if (_word[i] == mark[0])
                {
                    charToAdd = mark;
                }
            }
            if (charToAdd == "")
            {
                charToAdd = "_";
            }
            _hiddenWord += charToAdd;
        }
    }

    private void GenerateHiddenWord()
    {
        _isHidden = true;
        _hiddenWord = "";
        for (int i = 0; i <_word.Length; i++)
        {
            _hiddenWord += "_";
        }
    }

    public bool CheckIfHidden()
    {
        return _isHidden;
    }

    public void SetAsHidden()
    {
        _isHidden = true;
        if (_containsPunctuation)
        {
            GenerateHiddenWordWithPunctuation();
        }
        else
        {
            GenerateHiddenWord();
        }
    }

    public string GetHiddenWord()
    {
        return _hiddenWord;
    }

}