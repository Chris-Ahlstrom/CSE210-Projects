public class Breathe : Activity
{
    private string inhale = "Breathe in...";
    private string exhale = "Breathe out...";

    public Breathe(int num) : base(num)
    {}

    public void Breathing()
    {
        activityPrompt();
        Console.Write("Press enter to begin. ");
        Console.ReadLine();
        Console.Clear();
        Spinner(prep, spin, 10, 250);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_activityDuration);
        DateTime currentTime = DateTime.Now;
        do
        {
            Console.Clear();
            Spinner(inhale, countdown, 2.5, 1000);
            Console.Clear();
            Spinner(exhale, countdown, 2.5, 1000);
            currentTime = DateTime.Now;
        } while (currentTime < futureTime);
        endMessage();
    }

}