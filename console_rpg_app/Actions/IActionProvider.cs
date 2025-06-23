public interface IActionProvider
{
    IEnumerable<IGameAction> GetActionTemplates();
}