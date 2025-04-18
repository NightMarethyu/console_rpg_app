public class ContainerItem : Item
{
    public Inventory Inventory { get; private set; }

    public ContainerItem()
    {
        this.ID = "chest";
        this.Name = "Chest";
        this.Description = "A weathered wooden chest bound in iron, its surface scarred by time and battle";
        this.Type = ItemType.Container;
        this.Inventory = new Inventory();
    }

    public ContainerItem(string id, string name, string description) : base(id, name, description, ItemType.Container)
    {
        this.Inventory = new Inventory();
    }

    public ContainerItem(int size) : this()
    {
        this.Inventory = new Inventory(size);
    }

    public ContainerItem(string id, string name, string description, int size) : base(id, name, description, ItemType.Container)
    {
        this.Inventory = new Inventory(size);
    }
}