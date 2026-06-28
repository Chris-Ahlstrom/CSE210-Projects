public class Checklist : Goal
{
    private int _occurences;
    private int _completions;
    private int _bonus;
    private bool _bonusReceived;

    public Checklist(string name, string description, int points, int occurences, int bonus) : base(name, description, points)
    {
        _occurences = occurences;
        _bonus = bonus;
        _bonusReceived = false;
    }

    public override string GetGoalDetails()
    {
        string details = "ChecklistGoal|" + _name + "|" + _description + "|" + _points + "|" + _bonus + "|" + _occurences + "|" + _completions;
        return details;
    }

    public override int RecordEvent()
    {
        int score = _points;
        _completions ++;
        if (_completions >= _occurences && !_bonusReceived)
        {
            _bonusReceived = true;
            _isComplete = true;
        }
        if (_bonusReceived)
        {
            score += _bonus;
        }
        return score;
    }

    public void setState(int completions)
    {
        _completions = completions;
    }

    public override string GetName()
    {
        return _name + "-- Currently completed: " + _completions + "/" + _occurences;
    }
}