public abstract class Item
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Value { get; private set; }
    public bool IsStackable { get; private set; }
    public int Quantity { get; set; }

    protected Item(Guid id, string name, string description, int value, bool isStackable, int quantity)
    {
        Id = id;
        Name = name;
        Description = description;
        Value = value;
        IsStackable = isStackable;
        Quantity = quantity;
    }
}