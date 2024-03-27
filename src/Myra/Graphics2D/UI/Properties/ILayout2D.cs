namespace Myra.Graphics2D.UI.Properties
{
    public interface ILayout2D
    {
        bool IsActive { get; }

        bool TryCalculateWidth(Widget widget, out int width);
        bool TryCalculateHeight(Widget widget, out int height);
        bool TryCalculateX(Widget widget, out int x);
        bool TryCalculateY(Widget widget, out int y);
    }
}
