using System.ComponentModel.Design;

public class CombatScene : IScene
{
    private readonly CharacterManager _characterManager;
    private readonly Player _player;
    private readonly List<Guid> _enemies;
    private readonly List<Guid> _allies;

    private List<Character> _combatants = new List<Character>();

    private record MenuItem<T>(string Name, T Value);
    private enum PlayerTurnState { SelectingAction, SelectingTarget, ActionConfirmed }

    public CombatScene(CharacterManager characterManager, CombatState combatState)
    {
        _characterManager = characterManager;
        _player = (Player)combatState.Self;
        _enemies = combatState.EnemyIds;
        _allies = combatState.AllyIds;

        _combatants.Add(_player);

        foreach (var enemy in _enemies)
        {
            _combatants.Add(_characterManager.GetCharacterById(enemy));
        }

        foreach (var ally in _allies)
        {
            _combatants.Add(_characterManager.GetCharacterById(ally));
        }
    }

    public void OnEnter()
    {
        Console.Clear();
    }

    public void OnExit()
    {
        Console.Clear();
    }

    private void RenderCombatStatus()
    {
        Console.Clear();
        Console.ResetColor();
        Console.WriteLine(GameStrings.CombatStrings.Title);

        foreach (var c in _combatants.Where(cb => cb.IsAlive))
        {
            Console.WriteLine(GameStrings.CombatStrings.CharacterStatus, c.Name, c.CurrentHP, c.MaxHP);
            Console.WriteLine($"  {GameStrings.CombatStrings.CharacterEffects}", GameStrings.CombatStrings.NoEffects);
            Console.WriteLine();
        }
    }

    public SceneTransition Run()
    {
        while (true)
        {
            // Step 1- Determine Turn Order, run through each character and make an Inititive call, ordering them in a list/array
            var turnOrder = _combatants.Where(c => c.IsAlive).OrderByDescending(c => c.Dexterity + Dice.D20()).ToList();
            // Step 2- Process turns, This will be where you let the enemy(s), ally(s), and the player take their turns.
            //           Build some private helper functions so that this Run can be cleaner and more readable, They can be something like "private void PlayerTurn()" and "private void EnemyTurn()"
            foreach (var combatant in turnOrder)
            {
                if (!combatant.IsAlive) continue;

                bool cannotAct = combatant.Statuses.Contains(CharacterStatus.Fleeing) ||
                    combatant.Statuses.Contains(CharacterStatus.Paralyzed) ||
                    combatant.Statuses.Contains(CharacterStatus.Dead);

                if (cannotAct) continue;

                if (combatant.Id == _player.Id)
                {
                    PlayerTurn();
                } else if (combatant is Enemy enemy)
                {
                    EnemyTurn(enemy);
                }
            }

            foreach (var combatant in turnOrder)
            {
                // TODO Add status effects here, i.e. take damage from posion or burns
            }
            // Step 3- Check if the battle is over (i.e. all the enemies are dead, the enemies have all fled, the player is dead, or the player has fled. If it is over, break
            if (!_player.IsAlive) break;

            if (!_combatants.Any(c => c is Enemy && c.IsAlive)) break;

            //replaced code below with the line above, LINQ is super helpful to make things shorter and more human-readable
            /*bool enemiesLeft = false;
            foreach (var combatant in turnOrder)
            {
                if (combatant.IsAlive && combatant is Enemy)
                {
                    enemiesLeft = true;
                    break;
                }
            }
            if (!enemiesLeft) break;*/
        }

        if (!_player.IsAlive)
        {
            // TODO Add game over logic in player death, this is placeholder for now
            Console.WriteLine(GameStrings.CombatStrings.TargetKilled, "You");
            Thread.Sleep(2000);
            return new SceneTransition(SceneAction.EXIT_GAME, null);
        }

        Console.WriteLine(GameStrings.CombatStrings.EnemiesDefeated);
        Thread.Sleep(2000);
        return new SceneTransition(SceneAction.POP, null);
    }

    private void PlayerTurn()
    {
        RenderCombatStatus();
        Console.WriteLine(GameStrings.CombatStrings.PlayerTurnPrompt);

        // 1. Select Action
        var actionMenuItems = _player.combatActions
            .Select(action => new MenuItem<ICombatAction>(action.GetDescription(_player), action))
            .ToList();

        var selectedAction = ShowMenuAndGetChoice(actionMenuItems);

        // 2. Select Target (if required)
        Character selectedTarget = null;
        List<Character> potentialTargets = new List<Character>();

        switch (selectedAction.TargetOfType)
        {
            case TargetType.Self:
                selectedTarget = _player;
                break;
            case TargetType.Enemy:
                potentialTargets = _combatants.Where(c => c.IsAlive && c is Enemy).ToList();
                break;
            case TargetType.Ally:
                potentialTargets = _combatants.Where(c => c.IsAlive && c is not Enemy && c.Id != _player.Id).ToList();
                break;
            case TargetType.Any:
                potentialTargets = _combatants.Where(c => c.IsAlive).ToList();
                break;
            case TargetType.SelfOrAlly:
                potentialTargets = _combatants.Where(c => c.IsAlive && c is not Enemy).ToList();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(selectedAction.TargetOfType));
        }

        if (potentialTargets.Count > 0)
        {
            Console.WriteLine($"Target for {selectedAction.Name}");
            var targetMenuItems = potentialTargets
                        .Select(t => new MenuItem<Character>(t.Name, t))
                        .ToList();
            if (!targetMenuItems.Any())
            {
                Console.WriteLine("No valid targets!");
                Thread.Sleep(1000);
                return;
            }
            selectedTarget = ShowMenuAndGetChoice(targetMenuItems);
        }

        /*if (selectedAction.TargetOfType == TargetType.Self)
        {
            selectedTarget = _player;
        }
        else
        {
            RenderCombatStatus();
            Console.WriteLine($"Target for {selectedAction.Name}:");

            var potentialTargets = _combatants.Where(c => c.IsAlive && c is Enemy).ToList();
            var targetMenuItems = potentialTargets
                .Select(t => new MenuItem<Character>(t.Name, t))
                .ToList();

            if (!targetMenuItems.Any())
            {
                Console.WriteLine("No valid targets!");
                Thread.Sleep(1000);
                return;
            }
            selectedTarget = ShowMenuAndGetChoice(targetMenuItems);
        }*/

        // 3. Execute and Report
        if (selectedTarget != null)
        {
            int hpBefore = selectedTarget.CurrentHP;
            selectedAction.Execute(_player, selectedTarget);
            int damageDealt = hpBefore - selectedTarget.CurrentHP;

            Console.WriteLine();
            if (damageDealt > 0)
            {
                Console.WriteLine(GameStrings.CombatStrings.AttackInformation, _player.Name, selectedTarget.Name, damageDealt);
            }

            if (!selectedTarget.IsAlive)
            {
                Console.WriteLine(GameStrings.CombatStrings.TargetKilled, selectedTarget.Name);
            }
        }
        
        Thread.Sleep(500);
    }

    private void EnemyTurn(Enemy character)
    {
        List<Guid> playerAllies = new List<Guid>();
        playerAllies.Add(_characterManager.PlayerID);
        playerAllies.AddRange(_allies);
        
        var (action, targetId) = character.AI.ChooseAction(new CombatState(character, _enemies, playerAllies));
        if (action != null && targetId != Guid.Empty)
        {
            var target = _characterManager.GetCharacterById(targetId);
            if (target != null)
            {
                action.Execute(character, target);
            }
        } else
        {
            Console.WriteLine($"{character.Name} doesn't know what to do!");
        }
    }

    private T ShowMenuAndGetChoice<T>(List<MenuItem<T>> items)
    {
        int selectedIndex = 0;
        ConsoleKeyInfo keyInfo;

        int menuTop = Console.CursorTop;

        Console.CursorVisible = false;

        do
        {
            for (int i = 0; i < items.Count; i++)
            {
                // Position the cursor at the start of the line for the current menu item.
                Console.SetCursorPosition(0, menuTop + i);

                bool isSelected = i == selectedIndex;

                if (isSelected)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    // Pad the string to ensure the highlight covers the full width,
                    // clearing any text from a previous, longer menu item.
                    Console.Write($"> {items[i].Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write($"  {items[i].Name}");
                }
            }

            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedIndex = (selectedIndex == 0) ? items.Count - 1 : selectedIndex - 1;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedIndex = (selectedIndex + 1) % items.Count;
            }
            // We are redrawing the whole menu each time, so no need to move the cursor up here.

        } while (keyInfo.Key != ConsoleKey.Enter);

        // 2. User has pressed Enter. Move the cursor to the top of the menu area.
        Console.SetCursorPosition(0, menuTop);

        // Crucially, reset the color before you start writing blank lines.
        Console.ResetColor();

        // 3. Create a blank line and write it over each line the menu occupied.
        string blankLine = new string(' ', Console.WindowWidth > 1 ? Console.WindowWidth - 1 : 80);
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine(blankLine);
        }

        // 4. Move the cursor back to where the menu started.
        // The next Console.WriteLine will now start in the correct spot.
        Console.SetCursorPosition(0, menuTop);

        // Don't forget to make the cursor visible again!
        Console.CursorVisible = true;

        return items[selectedIndex].Value;
    }
}