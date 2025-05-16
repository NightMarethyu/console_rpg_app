using System.Runtime.CompilerServices;

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
            List<MenuOption> options = new List<MenuOption>();
            foreach (Item item in player.CurrentLocation.Inventory.GetAllItems())
            {
                if (item is ContainerItem container)
                {
                    options.Add(new MenuOption(container.Name, () => container.Open()));
                }
            }
            InputManager.RunMenu(options);
            SceneManager.currentScene.Info = player.CurrentLocation.Describe();
        }
    }

    public override bool IsValid(Player player)
    {
        return player.CurrentLocation.Inventory != null && player.CurrentLocation.Inventory.HasItemType(ItemType.Container);
    }
}