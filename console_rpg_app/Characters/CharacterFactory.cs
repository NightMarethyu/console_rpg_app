public class CharacterFactory
{
    public Character CreateCharacter(CharacterBuilder builder, CharacterType type)
    {
        switch (type)
        {
            case CharacterType.Enemy:
                return new Enemy(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags);
            case CharacterType.Villager:
                return new Villager(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags);
            case CharacterType.Player:
                return new Player(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags);

            default:
                throw new ArgumentException($"Invalid character type: {type}");
        }
    }
}