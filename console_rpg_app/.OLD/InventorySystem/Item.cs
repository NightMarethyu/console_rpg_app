using System.Security.Cryptography.X509Certificates;

namespace OLD
{

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

    public interface IItemEffect
    {
        void Apply(Player player);
        void Remove(Player player);
    }


    public abstract class Item
    {
        public string ID
        {
            get; protected set;
        }
        public string Name
        {
            get; protected set;
        }
        public string Description
        {
            get; protected set;
        }
        public string? Effects
        {
            get; protected set;
        }
        public int? Value
        {
            get; protected set;
        }
        public int? NumUses
        {
            get; protected set;
        }
        public ItemType Type
        {
            get; protected set;
        }
        public bool IsTakeable { get; set; } = true;
        public int Quantity { get; set; } = 1;
        public bool IsStackable { get; set; } = false;
        public bool IsEquippable { get; set; } = false;
        public EquipmentSlots? EquipmentSlot
        {
            get; set;
        }

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

        public abstract Item Clone(int quantity);

        public virtual string Describe()
        {
            var parts = new List<string>();

            string prefix = IsStackable && Quantity > 1 ? $"{Name} x{Quantity}" : Name;

            parts.Add($"{prefix}: {Description}");

            if (Value != null)
            {
                int curVal = (int)Value * Quantity;
                parts.Add($"Value: {curVal}");
            }

            if (!string.IsNullOrEmpty(Effects))
                parts.Add($"Effects: {Effects}");

            return string.Join(" | ", parts);
        }

        public Item SplitStack(int amount)
        {
            if (!IsStackable || Quantity < amount)
                throw new InvalidOperationException("Cannot Split Stack");

            Quantity -= amount;
            var clone = Clone(amount);
            return clone;
        }
    }
}