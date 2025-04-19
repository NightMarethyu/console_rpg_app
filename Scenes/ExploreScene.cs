public class ExploreScene : Scene
{
    private Player player;
    private Parser parser;

    public ExploreScene(Player player, Parser parser)
    {
        this.player = player;
        this.parser = parser;
    }

    public override void Run()
    {
        Console.Write("> ");
        String? input = Console.ReadLine();

        if (input != null)
        {
            parser.Parse(player, player.CurrentLocation, input);
        }
    }

    public override void Enter()
    {
        parser.Parse(player, player.CurrentLocation, "help");
    }

}