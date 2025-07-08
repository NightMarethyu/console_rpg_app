public class CharacterFactory
{
    public Character CreateCharacter(CharacterBuilder builder, CharacterType type)
    {
        Character temp;
        switch (type)
        {
            case CharacterType.Enemy:

                temp =  new Enemy(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags, builder.EnemyAI);
                builder.Reset();
                return temp;
            case CharacterType.Villager:
                temp = new Villager(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags);
                builder.Reset();
                return temp;
            case CharacterType.Player:
                temp = new Player(builder._id, builder._name, builder._currentHP, builder._maxHP, builder._isAlive, builder._strength, builder._dexterity, builder._wisdom, builder._armorValue, builder._attackValue, builder._tags);
                builder.Reset();
                return temp;

            default:
                throw new ArgumentException($"Invalid character type: {type}");
        }
    }
}