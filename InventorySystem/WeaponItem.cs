public class WeaponItem : Item
{
    public int AttackValue { get; private set; }

    public WeaponItem()
    {
        ID = "sword";
        Name = "Sword";
        Description = "A plain steel sword with a worn leather-wrapped hilt";
        Type = ItemType.Weapon;
        AttackValue = 10;
    }

    public WeaponItem(string id, string name, string description, int value, int attackValue)
    {
        ID = id;
        Name = name;
        Description = description;
        Value = value;
        AttackValue = attackValue;
        Type = ItemType.Weapon;
    }

    public override Item Clone(int q)
    {
        return new WeaponItem() { Quantity = q };
    }
}