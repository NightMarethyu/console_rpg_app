
public class StaticWorldGenerator : IWorldGenerator
{
    private record LocationBlueprint(string Key, string Name, string[] Tags);
    private record ConnectionBlueprint(string From, string To);
    private record CharacterBlueprint(string Name, string LocationKey, string[] Tags, int hp, int armor, int attack, CharacterType Type);

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

    List<CharacterBlueprint> characterBlueprints = new List<CharacterBlueprint>
    {
        new("Player", "Campfire", new[] { CharacterTags.Player }, 100, 10, 5, CharacterType.Player),
        new("Hermit", "Shack", new[] { CharacterTags.Villager }, 10, 0, 0, CharacterType.Villager),
        new("Goblin", "Clearing", new[] { CharacterTags.Enemy }, 25, 2, 15, CharacterType.Enemy)
    };

    public WorldGenerationResult GenerateWorld()
    {
        var theMap = new Dictionary<Guid, Location>();
        var keyToGuideMap = new Dictionary<string, Guid>();
        var characters = new Dictionary<Guid, Character>();
        var playerID = Guid.Empty;
        Guid startingGuid = Guid.Empty;
        LocationBuilder lb = new LocationBuilder();
        CharacterBuilder cb = new CharacterBuilder();
        CharacterFactory cf = new CharacterFactory();
        
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

        foreach (var character in characterBlueprints)
        {
            cb.WithName(character.Name)
                .WithCurrentHP(character.hp)
                .WithMaxHP(character.hp)
                .SetStrength(Dice.D(6, 3))
                .SetWisdom(Dice.D(6, 3))
                .SetDexterity(Dice.D(6, 3))
                .SetArmorValue(character.armor)
                .SetAttackValue(character.attack);
            foreach (var tag in character.Tags)
            {
                cb.AddTag(tag);
            }

            var newCharacter = cf.CreateCharacter(cb, character.Type);
            characters.Add(newCharacter.Id, newCharacter);
            theMap[keyToGuideMap[character.LocationKey]].AddCharacter(newCharacter);

            if (character.Type == CharacterType.Player)
            {
                playerID = newCharacter.Id;
            }
        }

        startingGuid = keyToGuideMap["Campfire"];

        Console.WriteLine("World Build Complete");
        foreach (var (_, value) in theMap)
        {
            Console.WriteLine(value.Name);
        }
        Console.WriteLine("\nCharacters Generated");
        foreach (var (_, value) in characters)
        {
            Console.WriteLine($"{value.Name}");
        }

        return new WorldGenerationResult(theMap, startingGuid, characters, playerID);
    }
}