public class MoveCommand : Command
{
    public override string Name => "move";
    public override string Description => GameStrings.Commands.Move;
    public override string Usage => GameStrings.Commands.MoveUsage;
    public override CommandType Type => CommandType.Move;
    public override List<string> Aliases => GameStrings.Commands.MoveAliases;


    public override bool IsValid(Player player, Location location)
    {
        return location.HasConnected();
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        base.Execute(player, location, args);
        string locationName = "";
        for (int i = 1; i < args.Length; i++)
        {
            locationName += args[i] + " ";
        }
        locationName = locationName.Trim();
        player.SetLocation(location.GetNextLocation(locationName));
        Console.WriteLine();
        player.CurrentLocation.Describe();
        Console.WriteLine();
    }
}