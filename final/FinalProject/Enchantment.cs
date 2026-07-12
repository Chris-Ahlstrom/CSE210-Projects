public class Enchantment : Card
{
    public Enchantment() : base(_insert)
    {
        PromptSpellEffect();
        PromptAbilities();
    }
}