public class TakeCommand : Command
{
    public override string Name => "take";

    public override string Description => "Add an item to your inventory";

    public override string Usage => "take {item name}";
    public override CommandType Type => CommandType.Take;
    public override List<string> Aliases => new List<string> { "take", "get", "grab", "pick", "collect", "t" };


    public override void Execute(Player player, Location location, string[] args)
    {
        string itemName = args[1];

        Item? foundItem = location.Inventory?.GetItem(itemName);

        if (foundItem == null && location.Inventory != null)
        {
            foreach (var item in location.Inventory.GetAllItems())
            {
                if (item is ContainerItem container && container.IsOpen)
                {
                    foundItem = container.Inventory.GetItem(itemName);
                    if (foundItem != null)
                    {
                        container.Inventory.RemoveItem(foundItem);
                        break;
                    }
                }
            }
        }

        if (foundItem != null && foundItem.IsTakeable)
        {
            player.Inventory.AddItem(foundItem);
            Console.WriteLine("You have added " + foundItem.Name + " to your inventory");
        }
        else
        {
            Console.WriteLine("Can't take " + itemName);
        }
    }

    public override bool IsValid(Player player, Location location)
    {
        if (location.Inventory != null)
        {
            if (location.Inventory.GetAllItems().Any(item => item.IsTakeable))
            {
                return true;
            }
            else if (location.Inventory.HasItemType(ItemType.Container))
            {
                var items = location.Inventory.GetAllItems();
                foreach ( var item in items )
                {
                    if (item is ContainerItem i && i.IsOpen)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}