public class PromptGenerator
{
    public List<Prompt> _prompts = new List<Prompt>();
    private List<String> _promptText = new List<String>
    {"Who was the most interesting person I interacted with today?",
     "What was the best part of my day?",
     "How did I see the hand of the Lord in my life today?",
     "What was the strongest emotion I felt today?",
     "If I had one thing I could do over today, what would it be?",
     "What was the most spontaneous thing you did today?"};
    
    public void InitializePrompts()
    {
        for (int i = 0; i < _promptText.Count; i++)
        {
            Prompt prompt = new Prompt();
            prompt._prompt = _promptText[i];
            prompt._used = false;
            _prompts.Add(prompt);
        }
    }

    public String GetPrompt()
    {
        Console.WriteLine($"The are {_prompts.Count} prompts available.");
        CheckQueue();
        int _promptID;
        Random rnd = new Random();
        do
        {
            _promptID = rnd.Next(0, _prompts.Count);
        } while (_prompts[_promptID]._used == true);
        _prompts[_promptID]._used = true;
        return _prompts[_promptID]._prompt;
    }

    public void CheckQueue()
    {
        int _used = 0;
        foreach (Prompt prompt in _prompts)
        {
            if (prompt._used == true)
            {
                _used++;
            }
        }
        if (_used == _prompts.Count)
        {
            foreach (Prompt prompt in _prompts)
            {
                prompt._used = false;
            }
        }
    }
}