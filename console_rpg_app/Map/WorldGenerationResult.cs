﻿public record WorldGenerationResult(
    Dictionary<Guid, Location> Locations, 
    Guid StartingLocationID, 
    Dictionary<Guid, Character> Characters, 
    Guid PlayerID
);