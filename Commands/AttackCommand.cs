public class AttackCommand : Command
{
    public override string Name => "attack";
    public override string Description => "Hit the enemy with an attack";
    public override string Usage => "attack {enemy name}";

    public override bool IsValid(Player player, Location location)
    {
        return location.HasEnemies();
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        if (location.HasEnemies()) {
            SceneManager.SetScene(new BattleScene(player, SceneManager.currentScene, location.FindFirstEnemy(args[1])));
        } else
        {
            Console.WriteLine("There's no enemy in this location");
            return;
        }
    }
}