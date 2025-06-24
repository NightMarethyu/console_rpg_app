public class CharacterManager
{
    private Dictionary<Guid, Character> AllCharacters;
    public Guid PlayerID { get; }

    public CharacterManager(WorldGenerationResult worldGen)
    {
        AllCharacters = worldGen.Characters;
        PlayerID = worldGen.PlayerID;
    }

    public void RegisterCharacter(Character character)
    {
        if (!AllCharacters.ContainsKey(character.Id))
        {
            AllCharacters.Add(character.Id, character);
        }
    }

    public void UnregisterCharacter(Character character)
    {
        AllCharacters.Remove(character.Id);
    }

    public Character GetCharacterById(Guid id)
    {
        AllCharacters.TryGetValue(id, out Character character);
        return character;
    }
}