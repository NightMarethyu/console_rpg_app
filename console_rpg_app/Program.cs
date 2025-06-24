var worldGenerator = new StaticWorldGenerator().GenerateWorld();
var mapManager = new MapManager(worldGenerator);
var characterManager = new CharacterManager(worldGenerator);
