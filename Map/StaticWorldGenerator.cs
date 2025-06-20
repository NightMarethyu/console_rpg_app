
public class StaticWorldGenerator : IWorldGenerator
{
    public Dictionary<Guid, Location> GenerateWorld()
    {
        Dictionary<Guid, Location> theMap = new Dictionary<Guid, Location>();
        // TODO Add several locations for MVP build
        return theMap;
    }
}