public class MapManager
{
    public Dictionary<Guid, Location> Locations { get; private set; }
    public Guid CurrentLocation { get; private set; }

    public MapManager(WorldGenerationResult worldGen)
    {
        this.Locations = worldGen.Locations;
        this.CurrentLocation = worldGen.StartingLocationID;
    }

    public void MovePlayerTo(Guid destinationId)
    {
        if (this.Locations.ContainsKey(destinationId))
        {
            CurrentLocation = destinationId;
        }
        else
        {
            throw new KeyNotFoundException("Location does not exist");
        }
    }

    public string GetLocationDescription(Guid destinationId)
    {
        return Locations[destinationId].Name;
    }

    public Location GetCurrentLocation()
    {
        return Locations[CurrentLocation];
    }
}