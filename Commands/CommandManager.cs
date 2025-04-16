public static class CommandManager
{
    public static List<Command> Commands { get; private set; } = new List<Command>();
    public static void Initialize()
    {
        Commands.Add(new HelpCommand());
        Commands.Add(new MoveCommand());
        /*Commands.Add(new LookCommand());
        Commands.Add(new InventoryCommand());
        Commands.Add(new TakeCommand());
        Commands.Add(new DropCommand());
        Commands.Add(new UseCommand());
        Commands.Add(new TalkCommand());
        Commands.Add(new AttackCommand());
        Commands.Add(new FleeCommand());*/
    }
}