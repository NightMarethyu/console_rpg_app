public class ArmorItem : Item
{
    public int DefenseValue { get; private set; }

    public ArmorItem()
    {
        ID = "shield";
        Name = "Shield";
        Description = "A round wooden shield reinforced with iron bands";
        Type = ItemType.Armor;
        DefenseValue = 10;
    }

    public ArmorItem(string id, string name, string description, int defenseValue) : base(id, name, description, ItemType.Armor)
    {
        DefenseValue = defenseValue;
    }
}