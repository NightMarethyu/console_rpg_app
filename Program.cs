Player player = new Player();
Enemy enemy = new Enemy();

var loc0 = new Location(0);
var loc1 = new Location(1);
var loc2 = new InteractiveLocation(2);
var loc3 = new Location(3);
var loc4 = new Location(4);
var loc5 = new Location(5);
var loc6 = new Location(6);
var loc7 = new Location(7);
var loc8 = new InteractiveLocation(8);

loc0.AddLocation(loc3);
loc1.AddLocation(loc4);
loc1.AddLocation(loc2);
loc2.AddLocation(loc5);
loc3.AddLocation(loc4);
loc3.AddLocation(loc6);
loc6.AddLocation(loc7);

loc2.setTeleport(loc8);
loc8.setTeleport(loc2);

player.SetLocation(loc4);
enemy.SetLocation(loc7);

while (true)
{
    player.CurrentLocation.Describe();
    Console.Write("Which location do you want to travel to? ");
    String? input = Console.ReadLine();

    if (input == null)
    {
        continue;
    }

    player.SetLocation(player.CurrentLocation.getNextLocation(input));
}
