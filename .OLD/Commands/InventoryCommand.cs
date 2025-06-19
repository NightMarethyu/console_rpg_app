public class InventoryCommand : Command
{
    public override string Name => "inventory";

    public override string Description => GameStrings.Commands.Inventory;

    public override string Usage => GameStrings.Commands.InventoryUsage;

    public override List<string> Aliases => GameStrings.Commands.InventoryAliases;

    public override CommandType Type => CommandType.Inventory;

    public override bool IsValid(Player player)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        player.PlayerInventory();
    }
}