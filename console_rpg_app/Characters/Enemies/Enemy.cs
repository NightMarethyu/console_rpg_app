public class Enemy : Character
{
    public Enemy(Guid id, string name, int currentHP, int maxHP, bool isAlive, int strength, int dexterity, int wisdom, int armorValue, int attackValue, HashSet<string> tags) :
        base(id, name, currentHP, maxHP, isAlive, strength, dexterity, wisdom, armorValue, attackValue, tags)
    {
        this.Tags.Add(CharacterTags.Enemy);
    }
}