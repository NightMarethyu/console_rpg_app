public class MapManager
{
    public Dictionary<Guid, Location> Locations { get; private set; }
    public Guid CurrentLocation { get; private set; }

    public MapManager(IWorldGenerator worldGenerator)
    {
        WorldGenerationResult worldGen = worldGenerator.GenerateWorld();
        this.Locations = worldGen.Locations;
        this.CurrentLocation = worldGen.StartingLocationID;
    }
}