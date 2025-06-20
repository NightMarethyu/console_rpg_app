public interface IWorldGenerator
{
    Dictionary<Guid, Location> GenerateWorld();
}