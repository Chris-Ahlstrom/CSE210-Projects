public class Planeswalker : Card
{
    private string _startingLoyalty;

    public Planeswalker() : base(_insert)
    {
        PromptAbilities();
        Console.Write($"What is the starting loyalty of {_name}? ");
        _startingLoyalty = Console.ReadLine();
    }

    public Planeswalker(Dictionary<string, string> data) : base(data)
    {
        _startingLoyalty = data["StartingLoyalty"];
    }
}