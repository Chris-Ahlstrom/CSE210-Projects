public class Creature : Card
{
    private List<string> _creatureTypes = new List<string>();
    private static string _creatureTypeClarification = " (not including creature types)";

    public Creature() : base(_creatureTypeClarification)
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
    }
}