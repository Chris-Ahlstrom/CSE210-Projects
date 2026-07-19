public class Battle : Card
{
    private int _startingDefenseCounters;

    public Battle() : base(_insert)
    {
        PromptSpellEffect();
        Console.Write($"How many defense counters does {_name} start with? ");
        int temporary = 0;
        do
        {
            if(!int.TryParse(Console.ReadLine(), out temporary))
            {
                Console.Write("Please enter a valid non-negative integer: ");
            }
            else
            {
                if (temporary <= 0)
                {
                    Console.Write("Please enter a valid non-negative integer: ");
                }
            }
        } while (temporary <= 0);
        _startingDefenseCounters = temporary;
    }

    public Battle(Dictionary<string, string> data) : base(data)
    {
        _startingDefenseCounters = int.Parse(data["StartingDefenseCounters"]);
    }
}