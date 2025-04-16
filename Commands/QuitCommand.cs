public class QuitCommand : Command
{
    public override string Name => "quit";
    public override string Description => "\"quit\" | Close the game";

    public override bool IsValid(Player player, Location location)
    {
        return true; // Always valid
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        Environment.Exit(0);
    }
}