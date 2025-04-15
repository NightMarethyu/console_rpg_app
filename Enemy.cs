using System;

public class Enemy : Character
{
	public Enemy() : base()
	{
		this.Name = "Goblin";
		this.HP = 15;
		this.AttackVal = 5;
	}

	/*public Enemy(string name) : this()
	{
		this.Name = name;
	}

	public Enemy(int hp) : this()
	{
		this.HP = hp;
	}
*/
}
