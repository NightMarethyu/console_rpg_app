public class ActionManager
{
    private readonly MapManager _mapManager;
    private readonly CharacterManager _characterManager;

    public ActionManager(MapManager mapManager, CharacterManager characterManager)
    {
        _mapManager = mapManager;
        _characterManager = characterManager;
    }

    public List<IGameAction> GetCurrentActions()
    {
        var context = new GameContext(_mapManager, _characterManager);

        var allTemplates = new List<IActionTemplate>();
        var currentLocation = _mapManager.GetCurrentLocation();
        allTemplates.AddRange(currentLocation.GetActionTemplates());
        
        var finalActions = new List<IGameAction>();
        foreach (var template in allTemplates)
        {
            finalActions.Add(template.ToAction(context));
        }

        return finalActions;
    }
}