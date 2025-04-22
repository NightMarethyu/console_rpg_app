public class DropCommand : Command
{
    public override string Name => "drop";

    public override string Description => GameStrings.Commands.Drop;

    public override string Usage => GameStrings.Commands.DropUsage;
    public override CommandType Type => CommandType.Drop;
    public override List<string> Aliases => GameStrings.Commands.DropAliases;


    public override void Execute(Player player, Location location, string[] args)
    {
        base.Execute(player, location, args);
        Item? item = player.Inventory.GetItem(args[1]);
        if (item != null && item.Type != ItemType.Quest)
        {
            if (item != null && item.IsStackable)
            {
                if (args.Length > 2)
                {
                    try
                    {
                        int quantity = int.Parse(args[2]);
                        if (item.Quantity >= quantity)
                        {
                            var droppedItem = ItemFactory.Create(item.ID, quantity);
                            item.Quantity -= quantity;
                            if (location.Inventory == null) { location.AddInventory(); }
                            location.Inventory.AddItem(droppedItem);
                        }
                        else
                        {
                            Console.WriteLine(GameStrings.Inventory.NotEnoughQuantity);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(GameStrings.Commands.DropUsage);
                        throw;
                    }
                    
                }
            } 
            else 
            {
                player.Inventory.RemoveItem(item);
                location.Inventory?.AddItem(item);
                Console.WriteLine(GameStrings.Inventory.YouDroppedItem, item.Name);
            }
        }
        else
        {
            Console.WriteLine(GameStrings.Inventory.QuestItemDropWarning);
        }
    }

    public override bool IsValid(Player player, Location location)
    {
        return player.Inventory.IsNotEmpty();
    }
}