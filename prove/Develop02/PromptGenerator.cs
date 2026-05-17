public class PromptGenerator
{
    public List<Prompt> _Prompts = new List<Prompt>();
    private List<String> _prompts = new List<String>
    {"Who was the most interesting person I interacted with today?",
     "What was the best part of my day?",
     "How did I see the hand of the Lord in my life today?",
     "What was the strongest emotion I felt today?",
     "If I had one thing I could do over today, what would it be?",
     "What was the most spontaneous thing you did today?"};
    
    public void InitializePrompts()
    {
        for (int i = 0; i < _prompts.Count; i++)
        {
            Prompt prompt = new Prompt();
            prompt._prompt = _prompts[i];
            prompt._used = false;
            _Prompts.Add(prompt);
        }
    }

    public String GetPrompt()
    {
        CheckQueue();
        int ID;
        Random rnd = new Random();
        do
        {
            ID = rnd.Next(0, _Prompts.Count);
        } while (_Prompts[ID]._used == true);
        _Prompts[ID]._used = true;
        return _Prompts[ID]._prompt;
    }

    public void CheckQueue()
    {
        int used = 0;
        foreach (Prompt prompt in _Prompts)
        {
            if (prompt._used == true)
            {
                used++;
            }
        }
        if (used == _Prompts.Count)
        {
            foreach (Prompt prompt in _Prompts)
            {
                prompt._used = false;
            }
        }
    }
}