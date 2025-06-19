using System;

public abstract class Character
{
    public string Name { get; protected set; }
    public int HP { get; protected set; }
    public int AttackVal { get; protected set; }
    public bool IsAlive { get; protected set; } = true;

    public int Strength { get; protected set; } 
    public int Dexterity { get; protected set; }
    public int Wisdom { get; protected set; }

    public Location? CurrentLocation { get; set; }

    public Inventory Inventory { get; protected set; }

    public int ArmorValue { get; protected set; }

    public Character()
	{
        this.Name = "Empty Character";
        this.HP = 0;
        this.AttackVal = 0;
        this.Inventory = new Inventory(this);
        this.Strength = Dice.D(6, 3);
        this.Dexterity = Dice.D(6, 3);
        this.Wisdom = Dice.D(6, 3);
	}

    public void TakeDamage(int damage)
    { 
        this.HP -= damage;
        if (this.HP <= 0)
        {
            this.Death();
        }
    }

    public virtual void SetLocation(Location location)
    {
        if (location != null)
        {
            this.CurrentLocation = location;
            location.AddCharacter(this);
        }
        else
        {
            throw new ArgumentException(GameStrings.ErrorMsgs.NoLocation);
        }
    }

    public virtual void SetHP(int val) { this.HP = val; }
    public virtual string Describe()
    {
        return this.Name;
    }

    public virtual void Death() { IsAlive = false; }

    public virtual int Speed()
    {
        return Dexterity + Dice.D20();
    }
}
