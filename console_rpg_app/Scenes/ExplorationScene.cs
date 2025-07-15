public class ExplorationScene : IScene
{
    private readonly MapManager _mapManager;
    private readonly ActionManager _actionManager;
    private readonly MenuService _menuService;

    public ExplorationScene(MapManager mapManager, ActionManager actionManager, MenuService menuService)
    {
        _mapManager = mapManager;
        _actionManager = actionManager;
        _menuService = menuService;
    }

    public SceneTransition Run()
    {
        // This is the scene's own game loop.
        while (true)
        {
            var currentLocation = _mapManager.GetCurrentLocation();
            var availableActions = _actionManager.GetCurrentActions();

            var viewComponents = new ViewBuilder()
                .AddText($"--- {currentLocation.Name} ---")
                .AddText("\nWhat do you want to do?")
                .Build();

            var menuItems = availableActions
                .Select(action => new MenuItem<IGameAction>(action.Description, action))
                .ToList();

            IGameAction chosenAction = _menuService.DisplayViewAndGetChoice(viewComponents, menuItems);

            return chosenAction.Execute();
        }
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}