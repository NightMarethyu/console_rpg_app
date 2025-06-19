public class TakeCommand : Command
{
    public override string Name => "take";

    public override string Description => GameStrings.Commands.Take;

    public override string Usage => GameStrings.Commands.TakeUsage;
    public override CommandType Type => CommandType.Take;
    public override List<string> Aliases => GameStrings.Commands.TakeAliases;


    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        var options = new List<MenuOption>();
        var locationInv = player.CurrentLocation.Inventory;
        var textOut = new List<string>();

        if (locationInv != null)
        {
            foreach (var item in locationInv.GetAllItems().Where(i => i.IsTakeable))
            {
                options.Add(new MenuOption(
                    item.Name,
                    () =>
                    {
                        locationInv.RemoveItem(item);
                        player.Inventory.AddItem(item);
                        textOut.Add(string.Format(GameStrings.Inventory.ItemAddedToInventory, item.Name));
                    }));
            }

            foreach (var container in locationInv.GetAllItems().OfType<ContainerItem>().Where(c => c.IsOpen))
            {
                foreach (var inner in container.Inventory.GetAllItems().Where(i=> i.IsTakeable))
                {
                    options.Add(new MenuOption(
                        $"{inner.Name} (from {container.Name})",
                        () =>
                        {
                            container.Inventory.RemoveItem(inner);
                            player.Inventory.AddItem(inner);
                            textOut.Add(string.Format(GameStrings.Inventory.ItemAddedToInventory, inner.Name));
                        }));
                }
            }
        }

        if (options.Count == 0)
        {
            textOut.Add("There's nothing to take here.");
            textOut.AddRange(player.CurrentLocation.Describe());
            SceneManager.currentScene.Info = textOut;
            return;
        }

        InputManager.RunMenu(options, prompt: "What would you like to take?");
        textOut.AddRange(player.CurrentLocation.Describe());

        SceneManager.currentScene.Info = textOut;
        /*string itemName = string.Join(" ", args.Skip(1)).Trim();

        Item? foundItem = player.CurrentLocation.Inventory?.GetItem(itemName);

        if (foundItem == null && player.CurrentLocation.Inventory != null)
        {
            foreach (var item in player.CurrentLocation.Inventory.GetAllItems())
            {
                if (item is ContainerItem container && container.IsOpen)
                {
                    foundItem = container.Inventory.GetItem(itemName);
                    if (foundItem != null && foundItem.IsTakeable)
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
        }*/
    }

    public override bool IsValid(Player player)
    {
        if (player.CurrentLocation.Inventory != null)
        {
            if (player.CurrentLocation.Inventory.GetAllItems().Any(item => item.IsTakeable))
            {
                return true;
            }
            else if (player.CurrentLocation.Inventory.HasItemType(ItemType.Container))
            {
                var items = player.CurrentLocation.Inventory.GetAllItems();
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