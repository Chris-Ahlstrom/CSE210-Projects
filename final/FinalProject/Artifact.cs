public class Artifact : Card
{
    public Artifact() : base(_insert)
    {
        PromptSpellEffect();
        PromptAbilities();
    }

    public Artifact(Dictionary<string, string> data) : base(data) 
    {}
}