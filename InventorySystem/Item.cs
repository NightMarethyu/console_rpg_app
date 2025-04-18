public enum ItemType
{
    Weapon,
    Armor,
    Consumable,
    Quest,
    Container,
    MagicTool,
    Misc
}

public abstract class Item
{
    public string ID { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string? Effects { get; protected set; }
    public int? Value { get; protected set; }
    public int? NumUses { get; protected set; }
    public ItemType Type { get; protected set; }
    public bool IsTakeable { get; protected set; } = true;

    public Item()
    {
        ID = string.Empty;
        Name = string.Empty;
        Description = string.Empty;
        Type = ItemType.Misc;
    }

    public Item(string id, string name, string description, ItemType type)
    {
        ID = id;
        Name = name;
        Description = description;
        Type = type;
    }

    public Item(string id, string name, string description, int value, ItemType type) : this(id, name, description, type)
    {
        Value = value;
    }

    public Item(string id, string name, string description, int value, ItemType type, string effects)
        : this(id, name, description, value, type)
    {
        Effects = effects;
    }

    public Item(string id, string name, string description, int value, ItemType type, string effects, int numUses)
        : this(id, name, description, value, type, effects)
    {
        NumUses = numUses;
    }

    public virtual string Describe()
    {
        if (Effects != null)
        {
            return $"{Name}: {Description} (Value: {Value}, Effects: {Effects})";
        }
        else if (Value != null)
        {
            return $"{Name}: {Description} (Value: {Value})";
        }
        else
        {
            return $"{Name}: {Description}";
        }
    }
}