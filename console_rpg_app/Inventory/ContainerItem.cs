public class ContainerItem : Item
{
    public Guid InventoryId { get; private set; }

    public ContainerItem(Guid id, string name, string description, int value, Guid inventoryId)
        : base(id, name, description, value, false, 1) // Inventories are not stackable
    {
        InventoryId = inventoryId;
    }
}