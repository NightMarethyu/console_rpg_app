using NSubstitute;

namespace console_rpg_app.Tests
{
    public class MapManagerTests
    {
        [Fact]
        public void Constructor_WhenGivenAWorldGenerator_SetsLocationsAndStartingID()
        {
            var fakeStartingId = Guid.NewGuid();
            var fakeLocation = new Location("Fake Town", id: fakeStartingId);
            var fakeMap = new Dictionary<Guid, Location> { {  fakeStartingId, fakeLocation } };
            var fakeResult = new WorldGenerationResult(fakeMap, fakeStartingId);

            var mockGenerator = Substitute.For<IWorldGenerator>();

            mockGenerator.GenerateWorld().Returns(fakeResult);

            var mapManager = new MapManager(mockGenerator);

            Assert.Single(mapManager.Locations);
            Assert.Equal(fakeStartingId, mapManager.CurrentLocation);
            Assert.Equal("Fake Town", mapManager.Locations[fakeStartingId].Name);
        }
    }
}
