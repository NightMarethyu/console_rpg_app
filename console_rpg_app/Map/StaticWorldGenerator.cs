
public class StaticWorldGenerator : IWorldGenerator
{
    private record LocationBlueprint(string Key, string Name, string[] Tags);
    private record ConnectionBlueprint(string From, string To);

    List<LocationBlueprint> locationBlueprints = new List<LocationBlueprint>
    {
        new("Campfire", "Cozy Campfire", new[] { LocationTags.StartingLocation, LocationTags.SafeZone} ),
        new("Path", "Worn Path", new[] { LocationTags.Path }),
        new("Shack", "Hermit's Shack", new[] { LocationTags.Building }),
        new("Stream", "Babbling Brook", new[] { LocationTags.Nature }),
        new("Clearing", "Gleaming Glade", new[] { LocationTags.Nature })
    };

    List<ConnectionBlueprint> connectionBlueprints = new List<ConnectionBlueprint>
    {
        new("Campfire", "Path"),
        new("Path", "Shack"),
        new("Path", "Stream"),
        new("Path", "Clearing")
    };

    public WorldGenerationResult GenerateWorld()
    {
        var theMap = new Dictionary<Guid, Location>();
        var keyToGuideMap = new Dictionary<string, Guid>();
        Guid startingGuid = Guid.Empty;
        LocationBuilder lb = new LocationBuilder();
        
        foreach (var blueprint in locationBlueprints)
        {
            lb.WithName(blueprint.Name);
            foreach (var tag in blueprint.Tags)
            {
                lb.AddTag(tag);
            }

            Location newLoc = lb.Build();

            theMap.Add(newLoc.Id, newLoc);
            keyToGuideMap.Add(blueprint.Key, newLoc.Id);
        }

        foreach (var connection in connectionBlueprints)
        {
            Guid fromId = keyToGuideMap[connection.From];
            Guid toId = keyToGuideMap[connection.To];

            Location fromLoc = theMap[fromId];
            Location toLoc = theMap[toId];

            fromLoc.AddExit(toId);
            toLoc.AddExit(fromId);
        }

        startingGuid = keyToGuideMap["Campfire"];

        Console.WriteLine("World Build Complete");
        foreach (var (_, value) in theMap)
        {
            Console.WriteLine(value.Name);
        }

        return new WorldGenerationResult(theMap, startingGuid);
    }
}