public class QuitCommand : Command
{
    public override string Name => "quit";
    public override string Description => GameStrings.Commands.Quit;
    public override string Usage => GameStrings.Commands.QuitUsage;
    public override CommandType Type => CommandType.Quit;
    public override List<string> Aliases => GameStrings.Commands.QuitAliases;


    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        Environment.Exit(0);
    }
}