public class OpenCommand : Command
{
    public override string Name => "open";

    public override string Description => GameStrings.Commands.Open;

    public override string Usage => GameStrings.Commands.OpenUsage;
    public override CommandType Type => CommandType.Open;
    public override List<string> Aliases => GameStrings.Commands.OpenAliases;


    public override void Execute(Player player, Location location, string[] args)
    {
        base.Execute(player, location, args);
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