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

            var (mapManager, _) = new TestWorldBuilder()
                                      .WithStartingLocation(fakeLocation)
                                      .Build();

            Assert.Single(mapManager.Locations);
            Assert.Equal(fakeStartingId, mapManager.CurrentLocation);
            Assert.Equal("Fake Town", mapManager.Locations[fakeStartingId].Name);
        }
    }
}
