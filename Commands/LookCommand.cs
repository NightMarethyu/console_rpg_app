public class LookCommand : Command
{
    public override string Name => "look";
    public override string Description => GameStrings.Commands.Look;
    public override string Usage => GameStrings.Commands.LookUsage;
    public override CommandType Type => CommandType.Look;
    public override List<string> Aliases => GameStrings.Commands.LookAliases;


    public override bool IsValid(Player player)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, string[] args)
    {
        player.CurrentLocation.Describe();
    }
}