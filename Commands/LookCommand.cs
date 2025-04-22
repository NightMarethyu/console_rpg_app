public class LookCommand : Command
{
    public override string Name => "look";
    public override string Description => GameStrings.Commands.Look;
    public override string Usage => GameStrings.Commands.LookUsage;
    public override CommandType Type => CommandType.Look;
    public override List<string> Aliases => GameStrings.Commands.LookAliases;


    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        location.Describe();
    }
}