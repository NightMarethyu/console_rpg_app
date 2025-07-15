public record TextComponent(string Text) : IViewComponent
{
    public void Render() => Console.WriteLine(Text);
}