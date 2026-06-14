public class Listing : Activity
{
    private List<string> _items = new List<string>();
    private List<string> _prompts = new List<string>{"Who are people that you appreciate?",
    "What are personal strengths of yours?", "Who are people that you have helped this week?", 
    "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    public Listing(int num) : base(num)
    {}

    public void promptListing()
    {
        activityPrompt();
        Console.Clear();
        Spinner(prep, spin, 10, 250);
        Random rnd = new Random();
        int prompt = rnd.Next(0, _prompts.Count);
        Console.WriteLine("List as many responses you can to the following prompt:");
        Console.WriteLine($" --- {_prompts[prompt]}");
        Spinner("You may begin in: ", countdown, 5, 1000);
        Console.WriteLine();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_activityDuration);
        DateTime currentTime = DateTime.Now;
        do
        {
            Console.Write("> ");
            _items.Add(Console.ReadLine());
            currentTime = DateTime.Now;
        } while (currentTime < futureTime);
        if (_items.Count == 1)
        {
            Console.WriteLine($"You listed {_items.Count} item!\n");
        }
        else
        {
            Console.WriteLine($"You listed {_items.Count} items!\n");
        }
        Console.WriteLine("Well done!!");
        Thread.Sleep(5000);
    }

}