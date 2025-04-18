public class ArmorItem : Item
{
    public int DefenseValue { get; private set; }


    public ArmorItem(string id, string name, string description, int defenseValue) : base(id, name, description, ItemType.Armor)
    {
        DefenseValue = defenseValue;
    }

    public override Item Clone(int quantity)
    {
        Item item = new ArmorItem(ID, Name, Description, DefenseValue);
        item.Quantity = quantity;
        item.IsTakeable = IsTakeable;
        item.IsStackable = IsStackable;
        return item;
    }
}