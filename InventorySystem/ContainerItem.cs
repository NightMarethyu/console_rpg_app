public enum ContainerState
{
    Closed,
    Open,
    Locked
    //Trapped,
    //Mimic
}

public class ContainerItem : Item
{
    public Inventory Inventory { get; private set; }
    public ContainerState State { get; private set; } = ContainerState.Closed;

    public bool IsOpen => State == ContainerState.Open;
    public bool isLocked => State == ContainerState.Locked;

    public ContainerItem(string id, string name, string description) : base(id, name, description, ItemType.Container)
    {
        this.Inventory = new Inventory();
    }

    public ContainerItem(string id, string name, string description, int size) : base(id, name, description, ItemType.Container)
    {
        this.Inventory = new Inventory(size);
    }

    public void Open()
    {
        if (isLocked)
        {
            Console.WriteLine(GameStrings.Container.Locked);
            return;
        }
        if (IsOpen)
        {
            Console.WriteLine(GameStrings.Container.Opened);
            return;
        }

        State = ContainerState.Open;
        Console.WriteLine(GameStrings.Container.OpenMessage, this.Name);
        Inventory.ListItems();
    }

    public void Lock() => State = ContainerState.Locked;
    public void Unlock(Player player)
    {
        if (player.Inventory.HasItem("key"))
        {
            State = ContainerState.Open;
            Console.WriteLine(GameStrings.Container.UnlockMessage, this.Name);
            return;
        }
        Console.WriteLine(GameStrings.Container.MissingKey);
    }

    public override string Describe()
    {
        string baseDesc = $"{Name}: {Description}";

        switch (State)
        {
            case ContainerState.Locked:
                return $"{baseDesc} (Locked)";
            case ContainerState.Closed:
                return $"{baseDesc} (Closed)";
            case ContainerState.Open:
                return $"{baseDesc} (Open)";
            default:
                return baseDesc;
        }
    }

    public override Item Clone(int quantity)
    {
        Item item = new ContainerItem(ID, Name, Description);
        return item;
    }
}