Player player = new Player();
Enemy enemy = new Enemy();
Parser parser = new Parser();
CommandManager.Initialize();

Console.OutputEncoding = System.Text.Encoding.UTF8;
//Console.WriteLine("Testing emoji: ⚡✨🧙‍♂️🗡️🚪");

var loc0 = new Location(0);
var loc1 = new Location(1);
var loc2 = new TeleportLocation(2);
var loc3 = new Location(3);
var loc4 = new Location(4);
var loc5 = new Location(5);
var loc6 = new Location(6);
var loc7 = new Location(7);
var loc8 = new TeleportLocation(8);

loc0.AddLocation(loc3);
loc1.AddLocation(loc4);
loc1.AddLocation(loc2);
loc2.AddLocation(loc5);
loc3.AddLocation(loc4);
loc3.AddLocation(loc6);
loc6.AddLocation(loc7);

loc2.SetTeleport(loc8);
loc8.SetTeleport(loc2);

loc8.AddInventory();
loc8.Inventory.AddItem(new ContainerItem());
Item loc8Chest = loc8.Inventory.GetItem("chest");

if (loc8Chest is ContainerItem chest)
{
    chest.Inventory.AddItem(new WeaponItem());
    chest.Inventory.AddItem(new ArmorItem());
}

player.SetLocation(loc4);
enemy.SetLocation(loc7);
parser.Parse(player, loc4, "help");
loc4.Describe();

while (true)
{
    Console.Write("> ");
    String? input = Console.ReadLine();

    if (input == null)
    {
        continue;
    }

    parser.Parse(player, player.CurrentLocation, input);
}
