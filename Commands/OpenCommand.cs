public class OpenCommand : Command
{
    public override string Name => "open";

    public override string Description => GameStrings.Commands.Open;

    public override string Usage => GameStrings.Commands.OpenUsage;
    public override CommandType Type => CommandType.Open;
    public override List<string> Aliases => GameStrings.Commands.OpenAliases;


    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        if (player.CurrentLocation.Inventory != null && player.CurrentLocation.Inventory.HasItemType(ItemType.Container))
        {
            if (player.CurrentLocation.Inventory.GetItem(args[1]) is ContainerItem container)
            {
                container.Open();
            }
        }
    }

    public override bool IsValid(Player player)
    {
        return player.CurrentLocation.Inventory != null && player.CurrentLocation.Inventory.HasItemType(ItemType.Container);
    }
}