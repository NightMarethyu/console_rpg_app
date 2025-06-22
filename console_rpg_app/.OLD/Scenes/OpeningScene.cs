namespace OLD
{

    public class OpeningScene : Scene
    {
        public OpeningScene(Player player) : base(player)
        {
        }

        public override void Run()
        {

        }

        public override void Enter()
        {
            base.Enter();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (string line in GameStrings.General.OpeningMonologue)
            {
                Console.WriteLine(line);
            }
            Console.ResetColor();
        }
    }
}