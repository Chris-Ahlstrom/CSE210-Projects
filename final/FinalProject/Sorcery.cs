public class Sorcery : Card
{
    public Sorcery() : base(_insert)
    {
        PromptSpellEffect();
    }

    public Sorcery(Dictionary<string, string> data) : base(data) 
    {}
}