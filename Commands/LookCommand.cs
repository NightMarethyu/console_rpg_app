public class LookCommand : Command
{
    public override string Name => "look";
    public override string Description => "Describes the current location";
    public override string Usage => "look";
    public override CommandType Type => CommandType.Look;
    public override List<string> Aliases => new List<string> { "look", "examine", "inspect", "l", "view", "observe" };


    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        location.Describe();
    }
}