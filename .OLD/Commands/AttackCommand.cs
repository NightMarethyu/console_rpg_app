using System.Runtime.CompilerServices;

public class AttackCommand : Command
{
    public override string Name => "attack";
    public override string Description => GameStrings.Commands.Attack;
    public override string Usage => GameStrings.Commands.AttackUsage;
    public override CommandType Type => CommandType.Attack;

    public override List<string> Aliases => GameStrings.Commands.AttackAliases;

    public override bool IsValid(Player player)
    {
        return player.CurrentLocation.HasEnemies();
    }

    public override void Execute(Player player, string[] args)
    {
        base.Execute(player, args);
        if (player.CurrentLocation.HasEnemies()) {
            var enemies = player.CurrentLocation.FindAllEnemies();
            if (enemies != null)
            {
                SceneManager.SetScene(new BattleScene(player, SceneManager.currentScene, enemies));
            }
            
        } else
        {
            Console.WriteLine("There's no enemy in this location");
            return;
        }
    }
}