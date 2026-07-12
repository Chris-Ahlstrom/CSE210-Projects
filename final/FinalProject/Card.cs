public class Card
{
    protected string _name;
    protected string _manaCost;
    protected string _cardType;
    protected bool _isLand = false;
    protected bool _isCommander = false;
    protected bool _isPermanent = true;
    protected bool _isLegendary = false;
    protected int _manaValue;
    protected List<string> _colors = new List<string>();
    protected List<string> _abilities = new List<string>();
    protected List<string> _subtypes = new List<string>();
    protected List<string> _effects = new List<string>();
    protected static string _insert = "";

    public Card(string insert)
    {
        Console.WriteLine("What is the name of the card you would like to add? ");
        _name = Console.ReadLine();
        Console.WriteLine("What is the mana cost of the card? \n(Ex. 1UW for a spell that costs one generic mana, one white mana and one blue mana)");
        _manaCost = Console.ReadLine();
        Console.Write($"Does the card have any subtypes{insert}? (y/n) ");
        string answer = Console.ReadLine();
        if (answer == "y")
        {
            Console.WriteLine("Please enter one subtype at a time and press enter after each one. Enter an empty line when you're finished.");
            string subtype = "";
            do
            {
                subtype = Console.ReadLine();
                if (subtype != "")
                {
                    _subtypes.Add(subtype);
                }
            }while (subtype != "");
        }
    }

    public void SetCardData()
    {}

    public void PromptAbilities()
    {
        Console.Write("Does the card have any abilities? (y/n) ");
        string answer = Console.ReadLine();
        if (answer == "y")
        {
            Console.WriteLine("Please enter one ability at a time and press enter after each one. Enter an empty line when you're finished.");
            Console.WriteLine("For the tap symbol type {Tap} and for the untap symbol type {Untap}");
            string ability = "";
            do
            {
                ability = Console.ReadLine();
                if (ability != "")
                {
                    _abilities.Add(ability);
                }
            }while (ability != "");
        }
    }

    public void PromptSpellEffect()
    {
            Console.WriteLine("Please enter one effect at a time and press enter after each one. Enter an empty line when you're finished.");
            Console.WriteLine("If the effect has you choose between modes, please enter the modes as separate effects.");
            string effect = "";
            do
            {
                effect = Console.ReadLine();
                if (effect != "")
                {
                    _effects.Add(effect);
                }
            }while (effect != "");
    }

    public string GetCardInfo()
    {}

    public void CostConverter()
    {}

    public List GetCreatureTypes()
    {}

    public List GetColors();

    public bool CheckIfPermanent()
    {
        return _isPermanent;
    }

    public bool CheckIfCommander()
    {
        return _isCommander;
    }

    public bool CheckIfLegendary()
    {
        return _isLegendary;
    }
    
    public bool CheckIfLand()
    {
        return _isLand;
    }
}