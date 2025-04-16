public class AttackCommand : Command
{
    public override string Name => "attack";
    public override string Description => "\"attack {enemy name}\" | Hit the enemy with an attack";

    public override bool IsValid(Player player, Location location)
    {
        return location.HasEnemies();
    }

    public override void Execute(Player player, Location location, string[] args)
    {
        if (location.EnemyExists(args[1])) {
            var enemy = location.FindFirstEnemy(args[1]);
            if (enemy != null)
            {
                player.Attack(enemy);
                Console.WriteLine("You attacked " + enemy.Name + " for " + player.AttackVal + " Damage");
                Console.WriteLine(enemy.Name + " has " + enemy.HP + " HP remaining");
            } else
            {
                Console.WriteLine("Enemy not found!");
                return;
            }
                
        } else
        {
            Console.WriteLine("There's no enemy here with the name " + args[1]);
            return;
        }
    }
}