public class TeleportCommand : Command
{
    public override string Name => "teleport";
    public override string Description => GameStrings.Commands.Teleport;
    public override string Usage => GameStrings.Commands.TeleportUsage;
    public override CommandType Type => CommandType.Teleport;
    public override List<string> Aliases => GameStrings.Commands.TeleportAliases;

    public override bool IsValid(Player player, Location location)
    {
        if (location is TeleportLocation)
        {
            TeleportLocation teleportLocation = (TeleportLocation)location;
            return teleportLocation.teleport != null;
        }
        return false; // Not valid if the location is not an TeleportLocation
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        base.Execute(player, location, args);
        if (location is TeleportLocation teleportLocation)
        {
            PrintTeleportEffect();

            Location target = teleportLocation.Teleport();
            player.SetLocation(target);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(GameStrings.Teleport.TeleportArrival);
            Console.ResetColor();
            Console.WriteLine();

            target.Describe();
        }
    }

    private void PrintTeleportEffect()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        foreach (var line in GameStrings.Teleport.ZapLines)
        {
            Console.WriteLine(line);
            Thread.Sleep(300);
        }

        Console.ResetColor();
    }

}
