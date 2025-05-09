public class DropCommand : Command
{
    public override string Name => "drop";

    public override string Description => GameStrings.Commands.Drop;

    public override string Usage => GameStrings.Commands.DropUsage;
    public override CommandType Type => CommandType.Drop;
    public override List<string> Aliases => GameStrings.Commands.DropAliases;


    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
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
                            if (player.CurrentLocation.Inventory == null) { player.CurrentLocation.AddInventory(); }
                            player.CurrentLocation.Inventory.AddItem(droppedItem);
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
                player.CurrentLocation.Inventory?.AddItem(item);
                Console.WriteLine(GameStrings.Inventory.YouDroppedItem, item.Name);
            }
        }
        else
        {
            Console.WriteLine(GameStrings.Inventory.QuestItemDropWarning);
        }
    }

    public override bool IsValid(Player player)
    {
        return player.Inventory.IsNotEmpty();
    }
}