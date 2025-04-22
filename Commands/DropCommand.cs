public class DropCommand : Command
{
    public override string Name => "drop";

    public override string Description => "Remove an item from your inventory and drop it in your current location";

    public override string Usage => "drop {item name} {optional: quantity}";
    public override CommandType Type => CommandType.Drop;
    public override List<string> Aliases => new List<string> { "drop", "discard", "throw", "remove", "leave", "d" };


    public override void Execute(Player player, Location location, string[] args)
    {
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
                            Console.WriteLine("You can't drop that many, not enough in your inventory");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"{Usage}");
                        throw;
                    }
                    
                }
            } 
            else 
            {
                player.Inventory.RemoveItem(item);
                location.Inventory?.AddItem(item);
                Console.WriteLine("You dropped " + item.Name);
            }
        }
        else
        {
            Console.WriteLine("You can't drop quest items!");
        }
    }

    public override bool IsValid(Player player, Location location)
    {
        return player.Inventory.IsNotEmpty();
    }
}