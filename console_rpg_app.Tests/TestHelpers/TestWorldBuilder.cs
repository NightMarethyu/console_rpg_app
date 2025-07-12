public class TestWorldBuilder
{
    private Guid _playerId;
    private Guid _startingLocationId;
    private Dictionary<Guid, Location> _locations = new();
    private Dictionary<Guid, Character> _characters = new();

    public TestWorldBuilder()
    {
        var player = new Player(Guid.NewGuid(), "Test Player", 100, 100, true, 10, 10, 10, 10, 10, new HashSet<string>());
        var startingLocation = new Location("Starting Location");

        _playerId = player.Id;
        _startingLocationId = startingLocation.Id;

        _characters.Add(_playerId, player);
        _locations.Add(_startingLocationId, startingLocation);
        startingLocation.AddCharacter(player);
    }

    public TestWorldBuilder WithStartingLocation(Location location)
    {
        _locations.Remove(_startingLocationId);
        _startingLocationId = location.Id;
        _locations.Add(_startingLocationId, location);
        location.AddCharacter(_characters[_playerId]);
        return this;
    }

    public TestWorldBuilder WithExits(int count)
    {
        var startingLocation = _locations[_startingLocationId];
        for (int i = 0; i < count; i++)
        {
            var newExit = new Location($"Exit Room {i + 1}");
            _locations.Add(newExit.Id, newExit);
            startingLocation.AddExit(newExit.Id);
        }
        return this;
    }

    public TestWorldBuilder WithEnemies(int count, bool isAlive = true)
    {
        var startingLocation = _locations[_startingLocationId];
        var factory = new CharacterFactory();
        var builder = new CharacterBuilder();

        for (int i = 0; i < count; i++)
        {
            var enemy = factory.CreateCharacter(
                builder.WithName($"Enemy {i + 1}")
                       .WithCurrentHP(isAlive ? 25 : 0)
                       .WithMaxHP(25)
                       .SetIsAlive(isAlive),
                CharacterType.Enemy);

            _characters.Add(enemy.Id, enemy);
            startingLocation.AddCharacter(enemy);
            builder.Reset();
        }

        return this;
    }

    public (MapManager, CharacterManager) Build()
    {
        var worldResult = new WorldGenerationResult(
            _locations,
            _startingLocationId,
            _characters,
            _playerId
        );

        MapManager mapManager = new(worldResult);
        CharacterManager characterManager = new(worldResult);

        return (mapManager, characterManager);
    }
}