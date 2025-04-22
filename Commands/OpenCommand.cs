public class OpenCommand : Command
{
    public override string Name => "open";

    public override string Description => "Access the contents of a container";

    public override string Usage => "open {item name}";
    public override CommandType Type => CommandType.Open;
    public override List<string> Aliases => new List<string> { "open", "o" };


    public override void Execute(Player player, Location location, string[] args)
    {
        if (location.Inventory != null && location.Inventory.HasItemType(ItemType.Container))
        {
            if (location.Inventory.GetItem(args[1]) is ContainerItem container)
            {
                container.Open();
            }
        }
    }

    public override bool IsValid(Player player, Location location)
    {
        return location.Inventory != null && location.Inventory.HasItemType(ItemType.Container);
    }
}