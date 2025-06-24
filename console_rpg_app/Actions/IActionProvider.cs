public interface IActionProvider
{
    IEnumerable<IActionTemplate> GetActionTemplates();
}