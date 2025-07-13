using NSubstitute;
using NSubstitute.ExceptionExtensions;
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

        [Fact]
        public void MovePlayerTo_Should_UpdateCurrentLocation_When_GivenValidDestinationId()
        {
            var (mapManager, _) = new TestWorldBuilder()
                                      .WithExits(1)
                                      .Build();

            Guid exit1 = mapManager.GetCurrentLocation().GetExitIDs().First();

            mapManager.MovePlayerTo(exit1);

            Assert.Equal(exit1, mapManager.CurrentLocation);
        }

        [Fact]
        public void MovePlayerTo_Should_ThrowKeyNotFoundException_When_GivenInvalidDestinationId()
        {
            var (mapManager, _) = new TestWorldBuilder()
                                      .WithExits(1)
                                      .Build();

            Assert.Throws<KeyNotFoundException>(() => mapManager.MovePlayerTo(Guid.NewGuid()));
        }

        [Fact]
        public void GetLocationDescription_Should_ReturnCorrectName_For_GivenLocationId()
        {
            Guid exit1 = Guid.NewGuid();
            string locName = "Unique Location";
            Location uniqueLocation = new(locName, exit1);

            var (mapManager, _) = new TestWorldBuilder()
                                      .WithSpecificExit(uniqueLocation)
                                      .Build();

            Assert.Equal("Starting Location", mapManager.GetLocationDescription(mapManager.CurrentLocation));
            Assert.Equal(locName, mapManager.GetLocationDescription(exit1));
        }

        [Fact]
        public void GetCurrentLocation_Should_ReturnTheCorrect_LocationObject()
        {
            Guid exitId = Guid.NewGuid();
            string locName = "Correct Object";
            Location location = new(locName, exitId);

            var (mapManager, _) = new TestWorldBuilder()
                                      .WithSpecificExit(location)
                                      .Build();
            
            mapManager.MovePlayerTo(exitId);

            Assert.Equal(exitId, mapManager.GetCurrentLocation().Id);
        }
    }
}
