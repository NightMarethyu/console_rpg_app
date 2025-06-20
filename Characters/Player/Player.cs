public class Player : Character
{
    public Player() : base()
    {
        this.Name = "Player Character";
        this.MaxHP = 100;
        this.CurrentHP = this.MaxHP;
        this.AttackValue = 5;
    }
    
    public Player(string name) : this() { this.Name = name; }

    public void Attack(Character en)
    {
        en.TakeDamage(this.AttackValue);
    }
}