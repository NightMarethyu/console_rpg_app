public enum EquipmentSlots
{
    Head,
    Chest,
    Legs,
    Feet,
    Hands,
    MainHand,
    OffHand,
    Ring,
    Amulet,
    Cloak,
    Belt
}

public class Player : Character
{
	public Dictionary<EquipmentSlots, Item?> PlayerEquipment = new Dictionary<EquipmentSlots, Item?>();

	public Player() : base()
	{
		this.Name = "Player Character";
		this.HP = 100;
		this.AttackVal = 5;
	}

	public Player(string name) : this() { this.Name = name; }

	public void Attack(Character en) { en.TakeDamage(this.AttackVal); }

    public void Equip(Item item)
    {
        if (item == null || !item.IsEquippable || item.EquipmentSlot == null) return;
        var slot = item.EquipmentSlot.Value;

        if (PlayerEquipment.ContainsKey(slot) && PlayerEquipment[slot] != null)
        {
            Item unequipped = PlayerEquipment[slot];
            RemoveItemEffects(unequipped);
            Inventory.AddItem(unequipped);
        }

        PlayerEquipment[slot] = item;
        Inventory.RemoveItem(item);
        ApplyItemEffects(item);
    }

    override public void SetLocation(Location location)
    {
        if (location != null)
            this.CurrentLocation = location;
        else
            throw new ArgumentException("Location not found!");
    }

    public override void Death()
    {
        base.Death();
        Console.WriteLine(GameStrings.General.YouHaveDied);
        Console.WriteLine(GameStrings.General.GameOver);
        Thread.Sleep(2000);
        Environment.Exit(0);
    }

    private void ApplyItemEffects(Item item)
    {
        switch (item)
        {
            case WeaponItem weapon:
                AttackVal += weapon.AttackValue;
                break;
            case ArmorItem armor:
                ArmorValue += armor.DefenseValue;
                break;
            default:
                if (item is IItemEffect effectItem) effectItem.Apply(this);
                break;
        }
    }

    private void RemoveItemEffects(Item item)
    {
        switch (item)
        {
            case WeaponItem weapon:
                AttackVal -= weapon.AttackValue;
                break;
            case ArmorItem armor:
                ArmorValue -= armor.DefenseValue;
                break;
            default:
                if (item is IItemEffect effectItem) effectItem.Remove(this);
                break;
        }
    }

}
