public class MapManager
{
    public Dictionary<Guid, Location> Locations { get; private set; }

    public MapManager(IWorldGenerator worldGenerator)
    {
        Locations = worldGenerator.GenerateWorld();
    }
}