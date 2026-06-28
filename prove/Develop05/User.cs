using System.Security;

public class User
{
    private string _userName;
    private int _score;

    private List<Goal> _goals = new List<Goal>();
    

    public User(string name)
    {
        _userName = name;
        _score = 0;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.");
        Thread.Sleep(2500);
    }

    public void LoadGoals()
    {
        Console.Write($"Would you like to load the goals in {_userName}.txt? (y/n) ");
        string _input = Console.ReadLine();
        string _fileName;
        if (_input == "n")
        {
            Console.Write("What file name do would you like to load goals from? ");
            _fileName = Console.ReadLine();
            if (!_fileName.Contains(".txt"))
            {
                _fileName = _fileName + ".txt";
            }
        }
        else
        {
            _fileName = _userName + ".txt";
        }
        string[] _lines = System.IO.File.ReadAllLines(_fileName);
        if (int.TryParse(_lines[0], out int tempScore))
        {
            _score = tempScore;
        }
        foreach (string _line in _lines)
        {
            string[] _parts = _line.Split("|");
            if(_parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(_parts[1], _parts[2], int.Parse(_parts[3]));
                if (_parts[4] == "true")
                {
                    goal.SetComplete();
                }
                _goals.Add(goal);
            }
            else if(_parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(_parts[1], _parts[2], int.Parse(_parts[3]));
                _goals.Add(goal);
            }
            else if(_parts[0] == "ChecklistGoal")
            {
                Checklist goal = new Checklist(_parts[1], _parts[2], int.Parse(_parts[3]), int.Parse(_parts[5]), int.Parse(_parts[4]));
                goal.setState(int.Parse(_parts[6]));
                _goals.Add(goal);
            }
            
        }
    }

    public void SaveGoals()
    {
        Console.Write("Would you like to save the journal under your name? (y/n) ");
        string input = Console.ReadLine();
        string fileName = "";
        if (input == "n")
        {
            Console.Write("What file name would you like to save your goals under? ");
            fileName = Console.ReadLine();
            if (!fileName.Contains(".txt"))
            {
                fileName = fileName + ".txt";
            }
        }
        else
        {
            fileName = _userName + ".txt";
        }
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine($"{goal.GetGoalDetails()}");
            }
        }
    }

    public void AddGoals(Goal goal)
    {
        _goals.Add(goal);
    }

    public List<string> GetGoals()
    {
        List<string> GoalNames = new List<string>();
        for (int index = 0; index < _goals.Count; index++)
        {
            string name = (index + 1) + ". ";
            if (_goals[index].GetStatus())
            {
                name += "[X] " + _goals[index].GetName();
            }
            else
            {
                name += "[ ] " + _goals[index].GetName();
            }
            GoalNames.Add(name);
        }
        return GoalNames;
    }

    public void MarkGoal(int index)
    {
        _score += _goals[index].RecordEvent();
    }
} 