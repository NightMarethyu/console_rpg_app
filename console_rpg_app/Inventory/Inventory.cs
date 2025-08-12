public class Inventory
{
    public Guid id { get; }
    private readonly List<Guid> _items = new();
    public IReadOnlyList<Guid> ItemIds => _items.AsReadOnly();

    public Inventory()
    {
        id = Guid.NewGuid();
    }

    public void AddItem(Guid id) { _items.Add(id); }
    public void RemoveItem(Guid id) { _items.Remove(id); }
    public bool HasItem(Guid id) => _items.Contains(id);
}