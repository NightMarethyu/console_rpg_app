public class MoveCommand : Command
{
    public override string Name => "move";
    public override string Description => "Move to a connected location or down a connected path";
    public override string Usage => "move {location name}";
    public override CommandType Type => CommandType.Move;
    public override List<string> Aliases => new List<string> { "move", "go", "walk", "travel", "m", "run" };


    public override bool IsValid(Player player, Location location)
    {
        return location.HasConnected();
    }

    public override void Execute(Player player, Location location, string[] args)
    {
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