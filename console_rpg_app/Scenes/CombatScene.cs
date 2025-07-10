using System.ComponentModel.Design;

public class CombatScene : IScene
{
    private readonly CharacterManager _characterManager;
    private readonly Player _player;
    private readonly List<Guid> _enemies;
    private readonly List<Guid> _allies;

    private List<Character> _combatants = new List<Character>();

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
        Console.WriteLine("Entering Combat Scene");
        Thread.Sleep(1000);
    }

    public void OnExit()
    {
        
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

        return new SceneTransition(SceneAction.POP, null);
    }

    private void PlayerTurn()
    {
        PlayerTurnState currentState = PlayerTurnState.SelectingAction;
        ICombatAction? selectedAction = null;
        Character? selectedTarget = null;

        while (currentState != PlayerTurnState.ActionConfirmed)
        {
            Console.Clear();
            // TODO Render the current combat status here.

            if (currentState == PlayerTurnState.SelectingAction)
            {
                Console.WriteLine("Choose your action:");
                var actionMenuItems = _player.combatActions
                    .Select(a => new MenuItem<ICombatAction>(a.Name, a))
                    .ToList();

                selectedAction = ShowMenuAndGetChoice(actionMenuItems);

                if (selectedAction.TargetOfType == TargetType.Self)
                {
                    selectedTarget = _player;
                    currentState = PlayerTurnState.ActionConfirmed;
                }
                else
                {
                    currentState = PlayerTurnState.SelectingTarget;
                }
            } else if (currentState == PlayerTurnState.SelectingTarget)
            {
                Console.WriteLine($"Choose a target for {selectedAction.Name}");
                var potentialTargets = new List<Character>();

                switch (selectedAction.TargetOfType)
                {
                    case TargetType.Enemy:
                        potentialTargets.AddRange(_combatants.Where(c => c is Enemy && c.IsAlive));
                        break;
                    case TargetType.Ally:
                        potentialTargets.AddRange(_combatants.Where(c => c is not Enemy && c.IsAlive && c.Id != _player.Id));
                        break;
                    case TargetType.Any:
                        potentialTargets.AddRange(_combatants);
                        break;
                    case TargetType.SelfOrAlly:
                        potentialTargets.AddRange(_combatants.Where(c => c is not Enemy && c.IsAlive));
                        break;
                    default:
                        break;
                }

                var targetMenuItems = potentialTargets
                    .Select(t => new MenuItem<Character>(t.Name, t))
                    .ToList();

                selectedTarget = ShowMenuAndGetChoice(targetMenuItems);
                currentState = PlayerTurnState.ActionConfirmed;
            }
        }

        Console.WriteLine($"Executing {selectedAction.Name} on {selectedTarget.Name}");
        selectedAction.Execute(_player, selectedTarget);
    }

    private void EnemyTurn(Enemy character)
    {
        List<Guid> playerAllies = new List<Guid>(_allies);
        playerAllies.Add(_characterManager.PlayerID);
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

        do
        {
            for (int i = 0; i < items.Count; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                bool isSelected = i == selectedIndex;

                if (isSelected)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"> {items[i].Name}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {items[i].Name}");
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

            Console.SetCursorPosition(0, Console.CursorTop - items.Count);
        } while (keyInfo.Key != ConsoleKey.Enter);

        return items[selectedIndex].Value;
    }

    private record MenuItem<T>(string Name, T Value);
    private enum PlayerTurnState { SelectingAction, SelectingTarget, ActionConfirmed }
}