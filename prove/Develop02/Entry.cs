public class Entry
{
    public string _entryDate;
    public string _prompt;
    public string _response;

    public void Display()
    {
        Console.WriteLine($"Date: {_entryDate} - Prompt: {_prompt}");
        Console.WriteLine($"{_response}");
    }

    public String GetDate()
    {
        DateTime _theCurrentTime = DateTime.Now;
        string _dateText = _theCurrentTime.ToShortDateString();
        return _dateText;
    }
}