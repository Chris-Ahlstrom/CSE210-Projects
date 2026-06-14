public class Activity
{
    protected List<string> _activityNames = new List<string>{"Breathing Activity", "Reflection Activity", "Listing Activity"};
    protected List<string> _activityDescriptions = new List<string>{
    "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.",
    "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
    "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area."};
    protected int _activityDuration;
    protected int _activityNum;
    protected string _activityName;
    protected string _activityDescription;
    protected string prep = "Get ready...\n";
    protected List<string> spin = new List<string>{"\\", "|", "/", "-"};
    protected List<string> countdown = new List<string>{"5", "4", "3", "2", "1"};

    public Activity(int choice)
    {
        _activityNum = choice - 1;
        _activityName = _activityNames[_activityNum];
        _activityDescription = _activityDescriptions[_activityNum];
    }
    public void activityPrompt()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine($"{_activityDescription}");
        Console.Write("How long, in seconds, would you like for your session to last? ");
        _activityDuration = int.Parse(Console.ReadLine());
        Console.Clear();
    }

    public void Spinner(string message, List<string> frames, double duration, int wait)
    {
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(duration);
        DateTime currentTime = DateTime.Now;
        Console.Write($"{message}");
        do
        {
            foreach(string frame in frames)
            {
                Console.Write($"{frame}");
                Thread.Sleep(wait);
                Console.Write("\b \b");
            }
            currentTime = DateTime.Now;
        }while(currentTime < futureTime);
    }
    
    public void endMessage()
    {
        Console.Clear();
        Console.WriteLine($"Congratulations on completing the {_activityName}!");
        Console.Write("Press enter to continue. ");
        Console.ReadLine();
    }
}