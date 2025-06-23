public abstract class Character
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int MaxHP { get; protected set; }
    public bool IsAlive { get; protected set; } = true;
    public int Strength { get; protected set; }
    public int Dexterity { get; protected set; }
    public int Wisdom { get; protected set; }
    public int ArmorValue { get; protected set; }
    public int AttackValue { get; protected set; }
    public HashSet<string> Tags = new HashSet<string>();
    //public Inventory Inventory { get; protected set; } // TODO implement Inventory class

    public Character()
    {
        this.Id = Guid.NewGuid();
        this.Name = string.Empty;
        this.MaxHP = 0;
        this.CurrentHP = 0;
        this.Strength = Dice.D(6, 3);
        this.Dexterity = Dice.D(6, 3);
        this.Wisdom = Dice.D(6, 3);
        this.ArmorValue = 0;
    }

    public Character(Guid id, string name, int currentHP, int maxHP, bool isAlive, int strength, int dexterity, int wisdom, int armorValue, int attackValue, HashSet<string> tags)
    {
        this.Id = id;
        this.Name = name;
        this.CurrentHP = currentHP;
        this.MaxHP = maxHP;
        this.Strength = strength;
        this.Dexterity = dexterity;
        this.Wisdom = wisdom;
        this.ArmorValue = armorValue;
        this.AttackValue = attackValue;
        this.Tags = tags;
    }

    public void Attack(Character target)
    {
        target.TakeDamage(this.AttackValue);
    }

    public void TakeDamage(int damage) 
    {
        this.CurrentHP -= damage;
        if (this.CurrentHP <= 0)
        {
            this.Death();
        }
    }

    public void Heal(int health) 
    {
        this.CurrentHP += health;
        if (CurrentHP > MaxHP)
        {
            CurrentHP = MaxHP;
        }
    }

    public virtual void Death()
    {
        this.IsAlive = false;
    }

}