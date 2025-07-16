public class AttackAction : IGameAction
{
    public string Description { get; }
    private readonly CharacterManager _characterManager;
    private readonly MapManager _mapManager;
    private readonly MenuService _menuService;
    private readonly Guid _player;
    private readonly Guid _target;

    public AttackAction(Guid player, Guid target, CharacterManager characterManager, MapManager mapManager, MenuService menuService)
    {
        _player = player;
        _target = target;
        Description = $"Attack {characterManager.GetCharacterById(_target).Name}";
        _characterManager = characterManager;
        _mapManager = mapManager;
        _menuService = menuService;
    }

    public SceneTransition? Execute()
    {
        var characterIds = _mapManager.GetCurrentLocation().GetCharacterIDs();
        List<Guid> allyIds = new List<Guid>();
        List<Guid> enemyIds = new List<Guid>();

        foreach (var characterId in characterIds)
        {
            if (characterId == _player) continue;
            if (_characterManager.GetCharacterById(characterId) is Enemy)
            {
                enemyIds.Add(characterId);
            } 
            else
            {
                allyIds.Add(characterId);
            }
        }

        var combatState = new CombatState(_characterManager.GetCharacterById(_player), allyIds, enemyIds);
        var combatScene = new CombatScene(_characterManager, combatState, _menuService);

        return new SceneTransition(SceneAction.PUSH, combatScene);
    }
}