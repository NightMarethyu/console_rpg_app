public class ItemData
{
    public string ID { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public ItemType Type { get; set; }
    public int? Value { get; set; }
    public string? Effects { get; set; }
    public int? NumUses { get; set; }
    public bool IsTakeable { get; set; }
    public int Quantity { get; set; } = 1;
    public bool IsStackable { get; set; } = false;
    public int? AttackValue { get; set; } // WeaponItem specific
    public int? DefenseValue { get; set; } // ArmorItem specific
    public bool IsEquipable { get; set; } = false;
    public int? MaxSize { get; set; }
    public EquipmentSlots? EquipmentSlot { get; set; }
}