public abstract class Character
{
    public string Name { get; protected set; }
    public int HP { get; protected set; }
    public bool IsAlive { get; protected set; } = true;
    public int Strength { get; protected set; }
    public int Dexterity { get; protected set; }
    public int Wisdom { get; protected set; }
    public int ArmorValue { get; protected set; }
    //public Inventory Inventory { get; protected set; } // TODO implement Inventory class

    public Character()
    {
        this.Name = string.Empty;
        this.HP = 0;
        this.Strength = Dice.D(6, 3);
        this.Dexterity = Dice.D(6, 3);
        this.Wisdom = Dice.D(6, 3);
        this.ArmorValue = 0;
    }
}