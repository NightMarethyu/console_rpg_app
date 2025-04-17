public class HelpCommand : Command
{
    public override string Name => "help";
    public override string Description => "Displays a list of available commands.";
    public override string Usage => "help";

    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        Console.WriteLine("Available commands:\n");

        var validCommands = CommandManager.Commands
            .Where(command => command.IsValid(player, location))
            .OrderBy(cmd => cmd.Name)
            .ToList();

        foreach (var command in validCommands)
        {
            // Command name
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"- {command.Name}");

            // Usage
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  > Usage       : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(command.Usage);

            // Description
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  > Description : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(command.Description);

            // Reset color
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
