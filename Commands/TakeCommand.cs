public class TakeCommand : Command
{
    public override string Name => "take";

    public override string Description => "Add an item to your inventory";

    public override string Usage => "take {item name}";

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

        if (foundItem != null)
        {
            player.Inventory.AddItem(foundItem);
            Console.WriteLine("You have added " + foundItem.Name + " to your inventory");
        }
        else
        {
            Console.WriteLine("No such item to take");
        }
    }

    public override bool IsValid(Player player, Location location)
    {
        return location.Inventory != null && location.Inventory.GetAllItems().Any(item => item.IsTakeable);
    }
}