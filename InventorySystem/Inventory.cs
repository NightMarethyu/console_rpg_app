using System.Runtime.CompilerServices;

public class Inventory
{
    private List<Item> items;
    private int? MaxSize;
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
        if (MaxSize == null || items.Count < MaxSize)
            items.Add(item);
        else
            Console.WriteLine("Inventory is full!");
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
            items.Remove(item);
        else
            Console.WriteLine("Item not found in inventory!");
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
        foreach (Item item in items)
        {
            if (item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase))
                return item;
        }
        //Console.WriteLine("Item not found in inventory!");
        return null;
    }

    public void ListItems()
    {
        if (items.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }
        Console.WriteLine("Items in inventory:");
        foreach (Item item in items)
        {
            Console.WriteLine("- " + item.Describe());
        }
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
}