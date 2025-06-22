public class CharacterBuilder
{
    public Guid _id = Guid.NewGuid();
    public string _name = string.Empty;
    public int _currentHP = 0;
    public int _maxHP = 0;
    public bool _isAlive = true;
    public int _strength = 0;
    public int _dexterity = 0;
    public int _wisdom = 0;
    public int _armorValue = 0;
    public int _attackValue = 0;
    public HashSet<string> _tags = new HashSet<string>();

    public CharacterBuilder()
    {
    }

    public CharacterBuilder Reset()
    {
        _id = Guid.NewGuid();
        _name = string.Empty;
        _currentHP = 0;
        _maxHP = 0;
        _isAlive = true;
        _strength = 0;
        _dexterity = 0;
        _wisdom = 0;
        _armorValue = 0;
        _attackValue = 0;
        _tags.Clear();

        return this;
    }

    public CharacterBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public CharacterBuilder WithID(Guid id)
    {
        _id = id;
        return this;
    }

    public CharacterBuilder WithCurrentHP(int currentHP)
    {
        _currentHP = currentHP;
        return this;
    }

    public CharacterBuilder WithMaxHP(int maxHP)
    {
        _maxHP = maxHP;
        return this;
    }

    public CharacterBuilder SetIsAlive(bool isAlive)
    {
        _isAlive = isAlive;
        return this;
    }

    public CharacterBuilder SetStrength(int strength)
    {
        _strength = strength;
        return this;
    }

    public CharacterBuilder SetDexterity(int dexterity)
    {
        _dexterity = dexterity;
        return this;
    }

    public CharacterBuilder SetWisdom(int wisdom)
    {
        _wisdom = wisdom;
        return this;
    }

    public CharacterBuilder SetArmorValue(int value)
    {
        _armorValue = value;
        return this;
    }

    public CharacterBuilder SetAttackValue(int value)
    {
        _attackValue = value;
        return this;
    }

    public CharacterBuilder AddTag(string tag)
    {
        _tags.Add(tag);
        return this;
    }
}