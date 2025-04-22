public class HelpCommand : Command
{
    public override string Name => "help";
    public override string Description => GameStrings.Commands.Help;
    public override string Usage => GameStrings.Commands.HelpUsage;
    public override CommandType Type => CommandType.Help;
    public override List<string> Aliases => GameStrings.Commands.HelpAliases;


    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        base.Execute(player, location, args);
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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("  > Aliases     : ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (string alias in command.Aliases) { Console.Write(alias + ", "); }
            Console.WriteLine();

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
