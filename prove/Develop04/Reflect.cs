public class Reflect : Activity
{
    private List<string> _questions = new List<string>{
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."};
    private List<string> _followUps = new List<string>{
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"};

    public Reflect(int num) : base(num)
    {}

    public void questionPrompt()
    {
        activityPrompt();
        Random rnd = new Random();
        int prompt = rnd.Next(0, _questions.Count);
        Spinner(prep, spin, 10, 250);
        Console.Clear();
        Console.WriteLine("Consider the following prompt:\n");
        Console.WriteLine($" --- {_questions[prompt]} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Spinner("You may begin in: ", countdown, 5, 1000);
        Console.Clear();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_activityDuration);
        DateTime currentTime = DateTime.Now;
        foreach (string question in _followUps)
        {
            Spinner("> " + question + " ", spin, 5, 250);
            Console.WriteLine();
            currentTime = DateTime.Now;
            if (currentTime >= futureTime)
            {
                break;
            }
        }
        endMessage();
    }
}