public class Enchantment : Card
{
    public Enchantment() : base(_insert)
    {
        PromptSpellEffect();
        PromptAbilities();
    }

    public Enchantment(Dictionary<string, string> data) : base(data) 
    {}
}