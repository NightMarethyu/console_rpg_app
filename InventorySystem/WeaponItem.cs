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
}