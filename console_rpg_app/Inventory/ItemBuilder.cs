public class ItemBuilder
{
    private Guid _id = Guid.NewGuid();
    private string _name = "Default Item";
    private string _description = "Default Item Description";
    private int _value = 0;
    private bool _isStackable = false;
    private int _quantity = 1;
    private EquipmentSlot? _slot;
    private Guid? _inventoryId;

    public ItemBuilder WithName(string name) { _name = name; return this; }
    public ItemBuilder WithDescription(string description) { _description = description; return this; }
    public ItemBuilder WithValue(int value) { _value = value; return this; }
    public ItemBuilder IsStackable(bool stackable) { _isStackable = stackable; return this; }
    public ItemBuilder WithQuantity(int quantity) { _quantity = quantity; return this; }
    public ItemBuilder WithEquipmentSlot(EquipmentSlot slot) { _slot = slot; return this; }
    public ItemBuilder WithInventoryId(Guid inventoryId) { _inventoryId = inventoryId; return this; }


    public void Reset()
    {
        _id = Guid.NewGuid();
        _name = "Default Item";
        _description = "Default Item Description";
        _value = 0;
        _isStackable = false;
        _quantity = 1;
        _slot = null;
        _inventoryId = null;
    }
}
