
public class StaticWorldGenerator : IWorldGenerator
{
    public WorldGenerationResult GenerateWorld()
    {
        Dictionary<Guid, Location> theMap = new Dictionary<Guid, Location>();
        Guid startingGuid = Guid.Empty;
        // TODO Add several locations for MVP build
        return new WorldGenerationResult(theMap, startingGuid);
    }
}