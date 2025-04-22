public enum CombatAction
{
    Attack,
    Defend,
    Flee
}

public class BattleScene : Scene
{
    public Scene PreviousScene { get; private set; }
    private List<string> battleLog;
    private Enemy enemy;

    public BattleScene(Player player, Scene previousScene, Enemy enemy) : base(player)
    {
        this.PreviousScene = previousScene;
        this.enemy = enemy;
    }

    public override void Run()
    {
        battleLog = new List<string>();
        // Display Battle Menu
        Console.WriteLine("\n-- What will you do? --");
        Console.WriteLine("1. Attack");
        //Console.WriteLine("2. Defend");
        //Console.WriteLine("3. Use Item");
        //Console.WriteLine("4. Flee");
        var key = Console.ReadKey();
        Console.WriteLine("\n");

        switch (key.Key)
        {
            case ConsoleKey.NumPad1:
                ResolveSpeed(CombatAction.Attack);
                break;
            case ConsoleKey.D1:
                ResolveSpeed(CombatAction.Attack);
                break;
            /*case ConsoleKey.NumPad2:
                ResolveSpeed(CombatAction.Defend);
                break;
            case ConsoleKey.D2:
                ResolveSpeed(CombatAction.Defend);
                break;
            case ConsoleKey.NumPad3:
                break;
            case ConsoleKey.D3:
                break;
            case ConsoleKey.NumPad4:
                break;
            case ConsoleKey.D4:
                break;*/
            default:
                Console.WriteLine("Invalid command\n");
                break;
        }

        foreach (string log in battleLog) Console.WriteLine(log);
        Console.WriteLine("\n--- End of Turn ---\n");

        if (!enemy.IsAlive)
        {
            Console.WriteLine("You have killed " + enemy.Name);
            IsRunning = false;
            PreviousScene.IsRunning = true;
            SceneManager.SetScene(PreviousScene);
        }
    }

    public override void Enter()
    {
        base.Enter();
        Console.WriteLine("This is the BattleScene");
    }

    public override void Exit()
    {
        IsRunning = false;
    }

    private void ResolveSpeed(CombatAction action)
    {
        if (player.Speed() >= enemy.Speed())
        {
            ResolvePlayerAction(action);
            if (enemy.HP > 0)
                ResolveEnemyAction();
            else
                enemy.Death();
        }
        else
        {
            ResolveEnemyAction();
            if (player.HP > 0)
            {
                ResolvePlayerAction(action);
            }
            else
            {
                foreach (string line in battleLog) Console.WriteLine(line);
                player.Death();
            }
        }
    }

    private void ResolvePlayerAction(CombatAction action)
    {
        switch (action)
        {
            case CombatAction.Attack:
                int attackDmg = player.AttackVal + Dice.D6();
                enemy.TakeDamage(attackDmg);
                battleLog.Add($"You attack the enemy for {attackDmg} damage");
                break;
            case CombatAction.Defend: break;
            case CombatAction.Flee: break;
            default: break;
        }
    }

    private void ResolveEnemyAction()
    {
        int attackDmg = enemy.AttackVal + Dice.D6();
        player.TakeDamage(attackDmg);
        battleLog.Add($"You take {attackDmg} damage from the enemy attack");
    }
}