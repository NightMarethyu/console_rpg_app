public interface IGameAction
{
    string Description { get; }
    void Execute();
}