public class ExploreScene : Scene
{
    public ExploreScene(Player play) : base(play) { }

    public override void Run()
    {
        var validCommands = CommandManager.Commands
            .Where(command => command.IsValid(player))
            .OrderBy(cmd => cmd.Name)
            .ToList();

        List<MenuOption> options = new List<MenuOption>();

        foreach (var command in validCommands)
        {
            string[] temp = ["temp"];
            MenuOption opt = new MenuOption(command.Name, () => command.Execute(player, temp));
            options.Add(opt);
        }

        InputManager.RunMenu(options, null, Info);

/*        Console.Write("> ");
        String? input = Console.ReadLine();

        if (input != null)
        {
            Parser.Parse(player, player.CurrentLocation, input);
        }*/
    }

    public override void Enter()
    {
        Parser.Parse(player, "help");
    }

}