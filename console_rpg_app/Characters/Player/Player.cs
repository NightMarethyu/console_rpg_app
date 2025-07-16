
public class Player : Character, IActionProvider
{
    public Player(Guid id, string name, int currentHP, int maxHP, bool isAlive, int strength, int dexterity, int wisdom, int armorValue, int attackValue, HashSet<string> tags) : 
        base(id, name, currentHP, maxHP, isAlive, strength, dexterity, wisdom, armorValue, attackValue, tags)
    {
        this.Tags.Add(CharacterTags.Player);
    }

    public Player(Guid id) : base()
    {
        this.Id = id;
    }

    public new void Attack(Character en)
    {
        en.TakeDamage(this.AttackValue);
    }

    public IEnumerable<IActionTemplate> GetActionTemplates()
    {
        List<IActionTemplate> actionTemplates = new List<IActionTemplate>();

        actionTemplates.Add(new QuitActionTemplate());

        return actionTemplates;
    }
}