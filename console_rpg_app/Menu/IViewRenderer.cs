public interface IViewRenderer
{

    int RenderComponents(List<IViewComponent> components);
    void RenderMenu<T>(MenuModel<T> menu, int cursorTopPosition = 0);
    void Render<T>(List<IViewComponent> components, MenuModel<T> menu);
    void Clear();
}