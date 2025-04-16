public class Help : Command
{
    public Help()
    {
        this.Name = "help";
        this.Description = "Displays a list of available commands.";
    }
    public override void Execute(string[] args)
    {
        Console.WriteLine("Available commands:");
        foreach (Command command in Commands)
        {
            Console.WriteLine($"{command.Name}: {command.Description}");
        }
    }
}
