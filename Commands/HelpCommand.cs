public class HelpCommand : Command
{
    public override string Name => "help";
    public override string Description => "\"help\" | Displays a list of available commands.";

    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        Console.WriteLine("Available commands:");
        foreach (var command in CommandManager.Commands)
        {
            Console.WriteLine($"- {command.Name}: {command.Description}");
        }
    }
}
