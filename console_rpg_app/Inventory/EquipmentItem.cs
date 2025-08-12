public class EquipmentItem : Item
{
    public EquipmentSlot Slot { get; protected set; }

    public EquipmentItem(Guid id, string name, string description, int value, EquipmentSlot slot, int quantity = 1)
        : base(id, name, description, value, false, quantity) // Equipment items aren't stackable
    {
        Slot = slot;
    }
}