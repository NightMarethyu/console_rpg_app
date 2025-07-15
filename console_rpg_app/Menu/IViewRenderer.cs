public interface IViewRenderer
{
    void Render<T>(List<IViewComponent> components, MenuModel<T> menu);
    void Clear();
}