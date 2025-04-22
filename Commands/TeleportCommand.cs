public class TeleportCommand : Command
{
    public override string Name => "teleport";
    public override string Description => "Teleport to a connected location or down a connected path";
    public override string Usage => "teleport";
    public override CommandType Type => CommandType.Teleport;
    public override List<string> Aliases => new List<string> { "teleport", "tp", "warp", "blink", "fasttravel", "portal" };

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
        if (location is TeleportLocation teleportLocation)
        {
            PrintTeleportEffect();

            Location target = teleportLocation.Teleport();
            player.SetLocation(target);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You feel your body reassemble in a new location...");
            Console.ResetColor();
            Console.WriteLine();

            target.Describe();
        }
    }

    private void PrintTeleportEffect()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string[] zapLines = new[]
        {
        "     ⚡⚡⚡ ✨✨✨ ⚡⚡⚡",
        "  > The runes shimmer as your body begins to fade...",
        "            ✨✨✨",
        "  > You vanish in a swirl of arcane energy...",
        "     ⚡⚡⚡ WHOOSH ⚡⚡⚡"
    };

        foreach (var line in zapLines)
        {
            Console.WriteLine(line);
            Thread.Sleep(300);
        }

        Console.ResetColor();
    }

}
