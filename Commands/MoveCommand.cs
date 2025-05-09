public class MoveCommand : Command
{
    public override string Name => "move";
    public override string Description => GameStrings.Commands.Move;
    public override string Usage => GameStrings.Commands.MoveUsage;
    public override CommandType Type => CommandType.Move;
    public override List<string> Aliases => GameStrings.Commands.MoveAliases;


    public override bool IsValid(Player player)
    {
        return player.CurrentLocation.HasConnected();
    }

    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        string locationName = "";
        for (int i = 1; i < args.Length; i++)
        {
            locationName += args[i] + " ";
        }
        locationName = locationName.Trim();
        player.SetLocation(player.CurrentLocation.GetNextLocation(locationName));
        Console.WriteLine();
        player.CurrentLocation.Describe();
        Console.WriteLine();
    }
}