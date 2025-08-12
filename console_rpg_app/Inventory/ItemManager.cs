public class ItemManager
{
    private readonly Dictionary<Guid, Item> _allItems = new();

    public void RegisterItem(Item item)
    {
        if (!_allItems.ContainsKey(item.Id))
        {
            _allItems.Add(item.Id, item);
        }
    }

    public Item GetItem(Guid id)
    {
        _allItems.TryGetValue(id, out var item);
        return item;
    }

    public void DeregisterItem(Guid id)
    {
        _allItems.Remove(id);
    }
}