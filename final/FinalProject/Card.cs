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
    protected int _copies;
    protected List<string> _colors = new List<string>();
    protected List<string> _abilities = new List<string>();
    protected List<string> _subtypes = new List<string>();
    protected List<string> _effects = new List<string>();
    protected static string _insert = "";

    public string Name => _name;
    public string ManaCost => _manaCost;
    public string CardType => _cardType;
    public bool IsLand => _isLand;
    public bool IsCommander => _isCommander;
    public bool IsPermanent => _isPermanent;
    public bool IsLegendary => _isLegendary;
    public int ManaValue => _manaValue;
    public int Copies => _copies;

    public IReadOnlyList<string> Colors => _colors;
    public IReadOnlyList<string> Abilities => _abilities;
    public IReadOnlyList<string> Subtypes => _subtypes;
    public IReadOnlyList<string> Effects => _effects;

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

    public Card(Dictionary<string, string> data)
    {
        _name = data["Name"];
        _manaCost = data["ManaCost"];
        _cardType = data["CardType"];
        _isLand = bool.Parse(data["IsLand"]);
        _isCommander = bool.Parse(data["IsCommander"]);
        _isPermanent = bool.Parse(data["IsPermanent"]);
        _isLegendary = bool.Parse(data["IsLegendary"]);
        _manaValue = int.Parse(data["ManaValue"]);
        _copies = int.Parse(data["Copies"]);
        _colors = data["Colors"].Split(';').ToList();
        _abilities = data["Abilities"].Split(';').ToList();
        _subtypes = data["Subtypes"].Split(';').ToList();
        _effects = data["Effects"].Split(';').ToList();
    }


    public void PromptForCopies()
    {
        Console.Write($"How many copies of {_name} would you like to add? ");
        int copiesToAdd = 0;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out copiesToAdd))
            {
                Console.Write("Please enter a valid non-negative integer. ");
            }
            else
            {
                if (copiesToAdd <= 0)
                {
                    Console.Write("Please enter a valid non-negative integer. ");
                }
            }
        }while (copiesToAdd <= 0);
        _copies = copiesToAdd;
    }
    
    public void SetCopies(int newCopyNum)
    {
        _copies = newCopyNum;
    }

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
    {
        return _name + " " + _manaCost;
    }

    public void CostConverter()
    {
        if (_manaValue == 0)
        {
            foreach (char c in _manaCost)
            {
                if (int.TryParse(c.ToString(), out int num))
                {
                    _manaValue += num;
                }
                else if (c.ToString() == "X")
                {
                    _manaValue += 0;
                }
                else
                {
                    _manaValue++;
                }
            }
        }
    }

    public int GetManaValue()
    {
        return _manaValue;
    }

    public List<string> GetColors()
    {
        return _colors;
    }

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