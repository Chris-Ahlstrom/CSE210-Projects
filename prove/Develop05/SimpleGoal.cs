public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description, points){}

    public override string GetGoalDetails()
    {
        string details = "SimpleGoal|" + _name + "|" + _description + "|" + _points + "|";
        if (_isComplete)
        {
            details = details + "true";
        }
        else
        {
            details = details + "false";
        }
        return details;
    }

}