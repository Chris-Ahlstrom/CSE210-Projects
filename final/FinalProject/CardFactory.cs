public static class CardFactory
{
    public static Card Create(Dictionary<string, string> data)
    {
        string type = data["CardType"];

        return type switch
        {
            "Land"         => new Land(data),
            "Creature"     => new Creature(data),
            "Artifact"     => new Artifact(data),
            "Instant"      => new Instant(data),
            "Sorcery"      => new Sorcery(data),
            "Enchantment"  => new Enchantment(data),
            "Battle"       => new Battle(data),
            "Planeswalker" => new Planeswalker(data),

            _ => new Card(data) // fallback for unknown types
        };
    }
}
