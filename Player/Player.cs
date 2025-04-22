using System;

public class Player : Character
{
	

	public Player() : base()
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
            this.CurrentLocation = location;
        else
            throw new ArgumentException("Location not found!");
    }

    public override void Death()
    {
        base.Death();
        Console.WriteLine(GameStrings.General.YouHaveDied);
        Console.WriteLine(GameStrings.General.GameOver);
        Thread.Sleep(2000);
        Environment.Exit(0);
    }
}
