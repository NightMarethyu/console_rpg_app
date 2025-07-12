using NSubstitute;
using System.Runtime.InteropServices;

namespace console_rpg_app.Tests
{
    public class MapManagerTests
    {
        [Fact]
        public void Constructor_WhenGivenAWorldGenerator_SetsLocationsAndStartingID()
        {
            // Create fake map
            Guid fakeStartingId = Guid.NewGuid();
            Location fakeLocation = new("Fake Town", id: fakeStartingId);
            Dictionary<Guid, Location> fakeMap = new() { {  fakeStartingId, fakeLocation } };

            // Create fake Players
            Guid fakePlayerId = Guid.NewGuid();
            Player character = new(fakePlayerId);
            Dictionary<Guid, Character> fakeCharacters = new() { { fakePlayerId, character } };

            // Build world
            WorldGenerationResult fakeResult = new(fakeMap, fakeStartingId, fakeCharacters, fakePlayerId);

            MapManager mapManager = new MapManager(fakeResult);

            Assert.Single(mapManager.Locations);
            Assert.Equal(fakeStartingId, mapManager.CurrentLocation);
            Assert.Equal("Fake Town", mapManager.Locations[fakeStartingId].Name);
        }
    }
}
