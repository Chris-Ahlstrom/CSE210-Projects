public class Land : Card
{
    private bool _isBasic = false;
    private List<string> _basicTypes = new List<string>{"Plains", "Island", "Swamp", "Mountain", "Forest"};

    public Land() : base(_insert)
    {
        PromptAbilities();
        string snow = "Snow-Covered";
        foreach (string type in _basicTypes)
        {
            if (_name == type)
            {
                _isBasic = true;
            }
            else if (_name.Contains(snow) && _name.Contains(type))
            {
                _isBasic = true;
            }
        }
        _isLand = true;
    }

    public Land(Dictionary<string, string> data) : base(data)
    {
        _isBasic = bool.Parse(data["IsBasic"]);
    }

    public bool CheckBasic()
    {
        return _isBasic;
    }
}