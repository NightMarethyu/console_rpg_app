public class ExploreScene : Scene
{
    public ExploreScene(Player play) : base(play) { }

    public override void Run()
    {
        Console.Write("> ");
        String? input = Console.ReadLine();

        if (input != null)
        {
            Parser.Parse(player, player.CurrentLocation, input);
        }
    }

    public override void Enter()
    {
        Parser.Parse(player, player.CurrentLocation, "help");
    }

}