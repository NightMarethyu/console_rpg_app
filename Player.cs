using System;

public class Player : Character
{
	

	public Player()
	{
		this.Name = "Player Character";
		this.HP = 100;
		this.AttackVal = 5;
	}

	public Player(string name) : this() { this.Name = name; }

	public void Attack(Character en) { en.TakeDamage(this.AttackVal); }

    override public void SetLocation(Location location)
    {
        if (location != null)
        {
            this.CurrentLocation = location;
        }
        else
        {
            throw new ArgumentException("Location not found!");
        }
    }
}
