public class ConsoleUserInput : IUserInput
{
    public ConsoleKey GetKey() => Console.ReadKey(true).Key;
}