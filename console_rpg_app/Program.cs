var worldGenerator = new StaticWorldGenerator().GenerateWorld();
var mapManager = new MapManager(worldGenerator);
var characterManager = new CharacterManager(worldGenerator);
var actionManager = new ActionManager(mapManager, characterManager);
var renderer = new ConsoleRenderer();

Thread.Sleep(2000);

// Print Opening Message
Console.Clear();
Console.WriteLine("Welcome to Echoes of Fate!");
Console.WriteLine("Use the Arrow Keys to navigate and Enter to select an action");
Console.WriteLine("Press any key to begin...");
Console.ReadLine();

// Game Loop
while (true)
{
    Console.Clear();

    var currentLocation = mapManager.GetCurrentLocation();
    var availableActions = actionManager.GetCurrentActions();

    if (!availableActions.Any())
    {
        Console.WriteLine("You have no available actions. The game is over.");
        break;
    }

    var menu = new Menu(availableActions);

    Console.WriteLine($"--- {currentLocation.Name} ---\n");

    int menuTopPosition = Console.CursorTop;
    ConsoleKeyInfo keyInfo;

    renderer.Render(menu, menuTopPosition);

    do
    {
        keyInfo = Console.ReadKey();

        if (keyInfo.Key == ConsoleKey.UpArrow)
        {
            menu.MoveUp();
        }
        else if (keyInfo.Key == ConsoleKey.DownArrow)
        {
            menu.MoveDown();
        }

        renderer.Render(menu, menuTopPosition);
    } while (keyInfo.Key != ConsoleKey.Enter);

    menu.Select();
    Console.ResetColor();
    Console.SetCursorPosition(0, menuTopPosition + menu.Actions.Count + 1);

}

Console.WriteLine("Thanks for playing!");