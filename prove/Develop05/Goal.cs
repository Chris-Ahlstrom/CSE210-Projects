public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public void SetComplete()
    {
        _isComplete = true;
    }

    public virtual int RecordEvent()
    {
        SetComplete();
        return _points;
    }
    public abstract string GetGoalDetails();

    public virtual string GetName()
    {
        return _name;
    }

    public bool GetStatus()
    {
        return _isComplete;
    }
}