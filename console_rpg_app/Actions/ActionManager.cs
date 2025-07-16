public class ActionManager
{
    private readonly MapManager _mapManager;
    private readonly CharacterManager _characterManager;
    private readonly MenuService _menuService;

    public ActionManager(MapManager mapManager, CharacterManager characterManager, MenuService menuService)
    {
        _mapManager = mapManager;
        _characterManager = characterManager;
        _menuService = menuService;
    }

    public List<IGameAction> GetCurrentActions()
    {
        var context = new GameContext(_mapManager, _characterManager, _menuService);

        var allTemplates = new List<IActionTemplate>();
        var currentLocation = _mapManager.GetCurrentLocation();

        allTemplates.AddRange(currentLocation.GetActionTemplates());

        foreach (var characterId in currentLocation.GetCharacterIDs())
        {
            var character = _characterManager.GetCharacterById(characterId);
            if (character is IActionProvider actionProvider && character.Id != _characterManager.PlayerID)
            {
                allTemplates.AddRange(actionProvider.GetActionTemplates());
            }
        }

        allTemplates.AddRange(((Player)_characterManager.GetCharacterById(_characterManager.PlayerID)).GetActionTemplates());

        var finalActions = new List<IGameAction>();
        foreach (var template in allTemplates)
        {
            finalActions.Add(template.ToAction(context));
        }

        return finalActions;
    }
}