using System;

public class Character
{
    protected string Name;
    protected int HP;
    protected int AttackVal;

    public Location? CurrentLocation { get; protected set; }

    public Character()
	{
        this.Name = "Empty Character";
        this.HP = 0;
        this.AttackVal = 0;
	}

    public void TakeDamage(int damage) { this.HP -= damage; }

    public virtual void SetLocation(Location location)
    {
        if (location != null)
        {
            this.CurrentLocation = location;
            location.AddCharacter(this);
        }
        else
        {
            throw new ArgumentException("Location not found!");
        }
    }

    public virtual void SetAttackVal(int val) { this.AttackVal = val; }
    public virtual void SetHP(int val) { this.HP = val; }
    public virtual string Describe()
    {
        return this.Name;
    }
}
