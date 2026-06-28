public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points){}

    public override string GetGoalDetails()
    {
        string details = "EternalGoal|" + _name + "|" + _description + "|" + _points;
        return details;
    }
    
}