using System.Runtime.CompilerServices;

public class Inventory
{
    private List<Item> items;
    public int? MaxSize { private get; set; }
    private Character? Owner;

    public Inventory()
    {
        items = new List<Item>();
    }

    public Inventory(int maxSize)
    {
        items = new List<Item>();
        MaxSize = maxSize;
    }

    public Inventory(Character owner)
    {
        items = new List<Item>();
        Owner = owner;
    }

    public Inventory(int maxSize, Character owner)
    {
        items = new List<Item>();
        MaxSize = maxSize;
        Owner = owner;
    }

    public void AddItem(Item item)
    {
        if (item.IsStackable)
        {
            var existing = items.FirstOrDefault(i => i.ID == item.ID && i.IsStackable);
            if (existing != null)
            {
                existing.Quantity += item.Quantity;
                return;
            }
        }

        if (MaxSize == null || items.Count < MaxSize)
            items.Add(item);
        else
            Console.WriteLine(GameStrings.Inventory.InventoryFull);
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
            items.Remove(item);
        else
            Console.WriteLine(GameStrings.Inventory.ItemNotFound);
    }

    public bool HasItem(string itemName)
    {
        foreach (Item item in items)
        {
            if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    public Item? GetItem(string itemName)
    {
        itemName = itemName.Trim().ToLower();

        Item? value = null;
        foreach (Item item in items)
        {
            if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                value = item;
        }
        value ??= GetItemByPartialName(itemName);
        //Console.WriteLine("Item not found in inventory!");
        return value;
    }

    private Item? GetItemByPartialName(string partialName)
    {
        partialName = partialName.Trim().ToLower();

        return items.FirstOrDefault(item =>
            item.Name.Equals(partialName, StringComparison.OrdinalIgnoreCase) ||
            item.ID.Equals(partialName, StringComparison.OrdinalIgnoreCase))
        ?? items.FirstOrDefault(item =>
            item.Name.StartsWith(partialName, StringComparison.OrdinalIgnoreCase) ||
            item.ID.StartsWith(partialName, StringComparison.OrdinalIgnoreCase))
        ?? items.FirstOrDefault(item =>
            item.Name.Contains(partialName, StringComparison.OrdinalIgnoreCase) ||
            item.ID.Contains(partialName, StringComparison.OrdinalIgnoreCase));
    }

    public List<string> ListItems()
    {
        List<string> list = new List<string>();

        if (items.Count == 0)
        {
            list.Add(GameStrings.Inventory.InventoryEmpty);
            return list;
        }

        foreach (Item item in items)
        {
            list.Add("- " + item.Describe());
        }
        return list;
    }

    public bool HasItemType(ItemType type)
    {
        foreach (Item item in items)
        {
            if (item.Type == type)
                return true;
        }
        return false;
    }

    public List<Item> GetAllItems() => new List<Item>(items);

    public void Combine(Inventory inventory)
    {
        foreach (Item item in inventory.items)
        {
            items.Add(item);
        }
    }

    public bool IsNotEmpty() => items.Count > 0;
}