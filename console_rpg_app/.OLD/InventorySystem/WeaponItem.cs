namespace OLD
{
}
public class WeaponItem : Item
{
    public int AttackValue { get; private set; }

    public WeaponItem(string id, string name, string description, int value, int attackValue)
    {
        ID = id;
        Name = name;
        Description = description;
        Value = value;
        AttackValue = attackValue;
        Type = ItemType.Weapon;
        IsEquippable = true;
    }

    public override Item Clone(int q)
    {
        return new WeaponItem(ID, Name, Description, Value ?? 0, AttackValue) { Quantity = q };
    }
}}