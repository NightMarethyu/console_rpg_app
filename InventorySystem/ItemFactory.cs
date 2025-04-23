using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class ItemFactory
{
    private static Dictionary<string, ItemData> dataRegistry = new();

    public static void LoadItemsFromJSON(string filepath)
    {
        var json = File.ReadAllText(filepath);
        var items = JsonSerializer.Deserialize<List<ItemData>>(json, new JsonSerializerOptions 
        { 
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        });

        if (items == null) return;

        foreach (var item in items)
        {
            dataRegistry[item.ID] = item;
        }
    }

    public static Item Create(string id, int quantity = 1)
    {
        if (!dataRegistry.ContainsKey(id))
            throw new ArgumentException($"Item ID '{id}' not found in data registry");

        var data = dataRegistry[id];
        return BuildItemFromData(data, quantity);
    }

    private static Item BuildItemFromData(ItemData data, int quantity)
    {
        Item item;

        switch (data.Type)
        {
            case ItemType.Weapon:
                item = new WeaponItem(data.ID, data.Name, data.Description, data.Value ?? 0, data.AttackValue ?? 0);
                break;
            case ItemType.Armor:
                item = new ArmorItem(data.ID, data.Name, data.Description, data.DefenseValue ?? 0, data.EquipmentSlot);
                break;
            case ItemType.Container:
                item = new ContainerItem(data.ID, data.Name, data.Description);
                if (item is ContainerItem itm && data.MaxSize != null)
                    itm.Inventory.MaxSize = data.MaxSize;
                break;
            default:
                item = new BasicItem(data.ID, data.Name, data.Description, data.Type, data.Value ?? 0);
                break;
        }

        item.Quantity = quantity;
        item.IsTakeable = data.IsTakeable;
        item.IsStackable = data.IsStackable;
        return item;
    }
}