namespace OLD
{

    public class TeleportCommand : Command
    {
        public override string Name => "teleport";
        public override string Description => GameStrings.Commands.Teleport;
        public override string Usage => GameStrings.Commands.TeleportUsage;
        public override CommandType Type => CommandType.Teleport;
        public override List<string> Aliases => GameStrings.Commands.TeleportAliases;

        public override bool IsValid(Player player)
        {
            if (player.CurrentLocation is TeleportLocation location)
            {
                return location.teleport != null;
            }
            return false; // Not valid if the location is not an TeleportLocation
        }

        public override void Execute(Player player, string[] args)
        {
            base.Execute(player, args);
            if (player.CurrentLocation is TeleportLocation location)
            {
                PrintTeleportEffect();
                Thread.Sleep(1000);

                Location target = location.Teleport();
                player.SetLocation(target);

                List<string> list = new List<string>();
                list.Add(GameStrings.Teleport.TeleportArrival);
                SceneManager.currentScene.Info = list;

                SceneManager.currentScene.Info.AddRange(target.Describe());
            }
        }

        private void PrintTeleportEffect()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            foreach (var line in GameStrings.Teleport.ZapLines)
            {
                Console.WriteLine(line);
                Thread.Sleep(300);
            }

            Console.ResetColor();
        }

    }
}