var worldGenerator = new StaticWorldGenerator().GenerateWorld();
var mapManager = new MapManager(worldGenerator);
var characterManager = new CharacterManager(worldGenerator);

var userInput = new ConsoleUserInput();
var viewRenderer = new ConsoleViewRenderer();
var menuService = new MenuService(viewRenderer, userInput);

var actionManager = new ActionManager(mapManager, characterManager, menuService);
var sceneManager = new SceneManager();

// create initial Scene
var baseScene = new ExplorationScene(mapManager, actionManager, menuService);
sceneManager.PushScene(baseScene);

Thread.Sleep(1000);

// Print Opening Message
Console.Clear();
Console.WriteLine("Welcome to Echoes of Fate!");
Console.WriteLine("Use the Arrow Keys to navigate and Enter to select an action");
Console.WriteLine("Press any key to begin...");
Console.ReadLine();

// Game Loop
sceneManager.Run();

Console.WriteLine("Thanks for playing!");