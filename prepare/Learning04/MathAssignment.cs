public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string section, string HW) : base(name, topic)
    {
        _textbookSection = section;
        _problems = HW;
    }
    
    public string GetHomeworkList()
    {
        return "Section " + _textbookSection + " Problems " +_problems;
    }
}