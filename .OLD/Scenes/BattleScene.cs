namespace OLD
{

    public enum CombatAction
    {
        Attack,
        Defend,
        Flee,
        None
    }

    public class BattleScene : Scene
    {
        public Scene PreviousScene
        {
            get; private set;
        }
        private List<string> battleLog;
        private List<Enemy> enemies;

        public BattleScene(Player player, Scene previousScene, List<Enemy> enemies) : base(player)
        {
            this.PreviousScene = previousScene;
            this.enemies = enemies.Where(e => e.IsAlive).ToList();
            battleLog = new List<string>();
        }

        public override void Run()
        {
            while (enemies.Any(e => e.IsAlive) && player.IsAlive)
            {
                var participants = new List<(Character character, int speed)>();
                participants.Add((player, player.Speed()));
                foreach (var enemy in enemies.Where(e => e.IsAlive))
                {
                    participants.Add((enemy, enemy.Speed()));
                }
                participants = participants.OrderByDescending(p => p.speed).ToList();

                foreach (var participant in participants)
                {
                    if (participant.character == player)
                    {
                        var action = ShowPlayerMenu();
                        if (action == CombatAction.Flee)
                        {
                            Console.WriteLine("You fled from battle.");
                            IsRunning = false;
                            return;
                        }
                        else if (action == CombatAction.Attack)
                        {
                            var target = SelectTarget();
                            if (target != null)
                            {
                                ResolvePlayerAttack(player, target);
                            }
                        }
                        else if (action == CombatAction.Defend)
                        {
                            Console.WriteLine("You defend.");
                        }
                    }
                    else
                    {
                        var enemy = (Enemy)participant.character;
                        ResolveEnemyAttack(enemy, player);
                    }
                }

                if (!enemies.Any(e => e.IsAlive))
                {
                    foreach (string line in battleLog)
                    {
                        Console.WriteLine(line);
                    }
                    Console.WriteLine("You have defeated all enemies.");
                    IsRunning = false;
                    PreviousScene.IsRunning = true;
                    SceneManager.SetScene(PreviousScene);
                }
            }
        }

        private CombatAction ShowPlayerMenu()
        {
            CombatAction chosenAction = CombatAction.None;
            List<MenuOption> options = new List<MenuOption>
        {
            new MenuOption(GameStrings.Battle.AttackOption, () => { chosenAction = CombatAction.Attack; }),
            new MenuOption(GameStrings.Battle.DefendOption, () => { chosenAction = CombatAction.Defend; }),
            new MenuOption(GameStrings.Battle.FleeOption, () => { chosenAction = CombatAction.Flee; }),
        };
            InputManager.RunMenu(options, GameStrings.Battle.WhatWillYouDo, battleLog);
            return chosenAction;
        }

        private Enemy? SelectTarget()
        {
            var aliveEnemies = enemies.Where(e => e.IsAlive).ToList();
            if (aliveEnemies.Count == 0)
            {
                return null;
            }
            Enemy? selectedEnemy = null;
            List<MenuOption> options = new List<MenuOption>();
            for (int i = 0; i < aliveEnemies.Count; i++)
            {
                int index = i;
                options.Add(new MenuOption($"{i + 1}. {aliveEnemies[i].Name}", () => { selectedEnemy = aliveEnemies[index]; }));
            }
            InputManager.RunMenu(options, "Select a target:", battleLog);
            return selectedEnemy;
        }

        private void ResolvePlayerAttack(Player player, Enemy target)
        {
            int attackDmg = player.AttackVal + Dice.D6();
            target.TakeDamage(attackDmg);
            string temp = string.Format(GameStrings.Battle.YouAttack, target.Name, attackDmg);
            battleLog.Add(temp);
            if (!target.IsAlive)
            {
                battleLog.Add($"{target.Name} has been defeated.");
            }
        }

        private void ResolveEnemyAttack(Enemy enemy, Player player)
        {
            int attackDmg = enemy.AttackVal + Dice.D6();
            player.TakeDamage(attackDmg);
            string temp = string.Format(GameStrings.Battle.EnemyAttack, enemy.Name, attackDmg);
            battleLog.Add(temp);
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
    }
}