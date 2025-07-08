var worldGenerator = new StaticWorldGenerator().GenerateWorld();
var mapManager = new MapManager(worldGenerator);
var characterManager = new CharacterManager(worldGenerator);
var actionManager = new ActionManager(mapManager, characterManager);
var sceneManager = new SceneManager();
var renderer = new ConsoleRenderer();

// create initial Scene
var baseScene = new ExplorationScene(mapManager, actionManager, renderer);
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