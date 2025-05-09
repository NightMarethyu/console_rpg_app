
public class EquipCommand : Command
{
    public override string Name => "equip";

    public override string Description => GameStrings.Commands.Equip;

    public override string Usage => GameStrings.Commands.EquipUsage;

    public override CommandType Type => CommandType.Equip;

    public override List<string> Aliases => GameStrings.Commands.EquipAliases;

    public override bool IsValid(Player player)
    {
        List<Item> items = player.Inventory.GetAllItems();
        return items.Any(item => item.IsEquippable);
    }

    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        string itemName = "";
        if (args.Length > 1)
        {
            itemName = string.Join(" ", args.Skip(1)).Trim();
        }
        if (itemName == "") 
        {
            Console.WriteLine(GameStrings.Inventory.ItemNotFound);
            return; 
        }

        Item? item = player.Inventory.GetItem(itemName);

        if (item == null)
        {
            Console.WriteLine(GameStrings.Inventory.ItemNotFound);
            return;
        }

        if (!item.IsEquippable)
        {
            Console.WriteLine(GameStrings.Inventory.NotEquippable);
            return;
        }

        player.Equip(item);
    }
}