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
                bool canAct = combatant.Statuses.Contains(CharacterStatus.Fleeing) ||
                    combatant.Statuses.Contains(CharacterStatus.Paralyzed) ||
                    combatant.Statuses.Contains(CharacterStatus.Dead);

                if (!canAct) continue;

                if (combatant.Id == _player.Id)
                {
                    PlayerTurn();
                } else
                {
                    EnemyTurn(combatant);
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

    }

    private void EnemyTurn(Character character)
    {

    }
}