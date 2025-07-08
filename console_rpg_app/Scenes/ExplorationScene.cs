public class ExplorationScene : IScene
{
    private readonly MapManager _mapManager;
    private readonly ActionManager _actionManager;
    private readonly ConsoleRenderer _consoleRenderer;

    public ExplorationScene(MapManager mapManager, ActionManager actionManager, ConsoleRenderer consoleRenderer)
    {
        _mapManager = mapManager;
        _actionManager = actionManager;
        _consoleRenderer = consoleRenderer;
    }

    public SceneTransition Run()
    {
        // This is the scene's own game loop.
        while (true)
        {
            Console.Clear();

            var currentLocation = _mapManager.GetCurrentLocation();
            var availableActions = _actionManager.GetCurrentActions();

            if (!availableActions.Any())
            {
                Console.WriteLine("You have no available actions. The game is over.");
                // We must return to the SceneManager to exit the game.
                return new SceneTransition(SceneAction.EXIT_GAME, null);
            }

            var menu = new Menu(availableActions);

            Console.WriteLine($"--- {currentLocation.Name} ---\n");

            int menuTopPosition = Console.CursorTop;
            _consoleRenderer.Render(menu, menuTopPosition);

            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true); // Changed to 'true' to hide the key press

                if (keyInfo.Key == ConsoleKey.UpArrow) menu.MoveUp();
                else if (keyInfo.Key == ConsoleKey.DownArrow) menu.MoveDown();

                _consoleRenderer.Render(menu, menuTopPosition);
            } while (keyInfo.Key != ConsoleKey.Enter);

            // Execute the selected action and capture the potential transition.
            var transition = menu.Select();

            // If the action returned a transition, exit this scene's loop
            // and return control to the SceneManager.
            if (transition != null && transition.action != SceneAction.NONE)
            {
                return transition;
            }

            // If the action did not return a transition (e.g., MoveAction),
            // the loop continues for the next turn in this scene.
            Console.ResetColor();
            Console.SetCursorPosition(0, menuTopPosition + menu.Actions.Count + 1);
        }
    }

    public void OnEnter()
    {

    }

    public void OnExit()
    {

    }
}