using System;

public class Enemy : Character
{
	public Enemy() : base()
	{
		this.Name = "Goblin";
		this.HP = 15;
		this.AttackVal = 5;
	}

	public Enemy(string name, int HP, int AttackVal)
	{
		this.Name = name;
		this.HP = HP;
		this.AttackVal = AttackVal;
	}

	public override void Death()
	{
		this.CurrentLocation?.RemoveCharacter(this);
    }

	/*public override bool Equals(object? obj)
    {
		return obj.ToString() == this.Name;
    }*/
}
