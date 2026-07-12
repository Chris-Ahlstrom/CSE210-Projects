public class Artifact : Card
{
    public Artifact() : base(_insert)
    {
        PromptSpellEffect();
        PromptAbilities();
    }
}