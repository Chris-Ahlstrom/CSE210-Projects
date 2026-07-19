public class Instant : Card
{

    public Instant() : base(_insert)
    {
        PromptSpellEffect();
    }

    public Instant(Dictionary<string, string> data) : base(data) 
    {}
}