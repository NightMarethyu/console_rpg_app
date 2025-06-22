namespace OLD
{

    public class MoveCommand : Command
    {
        public override string Name => "move";
        public override string Description => GameStrings.Commands.Move;
        public override string Usage => GameStrings.Commands.MoveUsage;
        public override CommandType Type => CommandType.Move;
        public override List<string> Aliases => GameStrings.Commands.MoveAliases;


        public override bool IsValid(Player player)
        {
            return player.CurrentLocation.HasConnected();
        }

        public override void Execute(Player player, string[] args)
        {
            base.Execute(player, args);

            // TODO implement menu with InputManager. Use loop to create the MenuOptions for each location in player.CurrentLocation.connected

            List<MenuOption> options = new List<MenuOption>();

            foreach (Location location in player.CurrentLocation.connected)
            {
                options.Add(new MenuOption(location.name, () => player.SetLocation(location)));
            }
            List<string> question = new List<string>();
            question.Add(GameStrings.LocationMsgs.MoveWhere);
            InputManager.RunMenu(options, null, question);
            SceneManager.currentScene.Info = player.CurrentLocation.Describe();
            //string locationName = "";
            //for (int i = 1; i < args.Length; i++)
            //{
            //    locationName += args[i] + " ";
            //}
            //locationName = locationName.Trim();
            //player.SetLocation(player.CurrentLocation.GetNextLocation(locationName));
            //Console.WriteLine();
            //player.CurrentLocation.Describe();
            //Console.WriteLine();
        }
    }
}