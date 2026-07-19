public class Creature : Card
{
    private List<string> _creatureTypes = new List<string>();
    private static string _creatureTypeClarification = " (not including creature types)";

    public Creature(bool _hasCommander) : base(_creatureTypeClarification)
    {
        Console.WriteLine("Please enter one creature type at a time and press enter after each one. Enter an empty line when you're finished.");
        string creatureType = "";
        do
        {
            creatureType = Console.ReadLine();
            if (creatureType != "")
            {
                _creatureTypes.Add(creatureType);
            }
        }while (creatureType != "");
        string answer;
        if (!_hasCommander)
        {
            Console.Write("Is this creature your commander? (y/n) ");
            answer = Console.ReadLine();
            if (answer == "y")
            {
                _isCommander = true;
                _isLegendary = true;                                                                                                                                                                                                                                                                                                                                                                                                
            }
        }
        else
        {
            Console.Write("Is this creature legendary? (y/n) ");
            answer = Console.ReadLine();
            if (answer == "y")
            {
                _isLegendary = true;
            }
        }
        PromptAbilities();
    }
   
    public Creature(Dictionary<string, string> data) : base(data)
    {
        _creatureTypes = data["CreatureTypes"].Split(';').ToList();
    }
    
    public List<string> GetCreatureTypes()
    {
        return _creatureTypes;
    }

    public bool CheckCommanderStatus()
    {
        return _isCommander;
    }
}