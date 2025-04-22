public class QuitCommand : Command
{
    public override string Name => "quit";
    public override string Description => "Close the game";
    public override string Usage => "quit";
    public override CommandType Type => CommandType.Quit;
    public override List<string> Aliases => new List<string> { "quit", "exit", "leave", "q", "bye" };


    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        Environment.Exit(0);
    }
}