public abstract class Character
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public int CurrentHP { get; protected set; }
    public int MaxHP { get; protected set; }
    public int Strength { get; protected set; }
    public int Dexterity { get; protected set; }
    public int Wisdom { get; protected set; }
    public int ArmorValue { get; protected set; }
    public int AttackValue { get; protected set; }
    public HashSet<CharacterStatus> Statuses { get; private set; } = new HashSet<CharacterStatus>();
    public HashSet<string> Tags = new HashSet<string>();
    public HashSet<ICombatAction> combatActions = new HashSet<ICombatAction>();

    public bool IsAlive => !this.Statuses.Contains(CharacterStatus.Dead);
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

        this.Statuses.Add(CharacterStatus.Alive);

        this.combatActions.Add(new BasicAttackAction());
        this.combatActions.Add(new BasicDefendAction());
        this.combatActions.Add(new FleeAction());
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
        Console.WriteLine($"{Name} was attacked for {damage} points of damage");
        Console.WriteLine($"{Name} has {CurrentHP} HP remaining");
        Thread.Sleep(500);
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
        this.Statuses.Clear();
        this.Statuses.Add(CharacterStatus.Dead);
    }

}