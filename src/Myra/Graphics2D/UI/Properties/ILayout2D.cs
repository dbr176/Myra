namespace Myra.Graphics2D.UI.Properties
{
    public interface ILayout2D
    {
        bool IsActive { get; }

        bool TryCalculateWidth(Widget widget, out int width);
        bool TryCalculateHeight(Widget widget, out int height);
        bool TryCalculateX(Widget widget, out int x);
        bool TryCalculateY(Widget widget, out int y);
        bool TryCalculateZ(Widget widget, out int z);
    }

    public interface ILayout2D<TWidget> : ILayout2D
        where TWidget : Widget
    {
        bool TryCalculateWidth(TWidget widget, out int width);
        bool TryCalculateHeight(TWidget widget, out int height);
        bool TryCalculateX(TWidget widget, out int x);
        bool TryCalculateY(TWidget widget, out int y);
        bool TryCalculateZ(TWidget widget, out int z);

        bool ILayout2D.TryCalculateWidth(Widget widget, out int width)
        {
            return TryCalculateWidth((widget as TWidget)!, out width);
        }
        bool ILayout2D.TryCalculateHeight(Widget widget, out int height)
        {
            return TryCalculateHeight((widget as TWidget)!, out height);
        }
        bool ILayout2D.TryCalculateX(Widget widget, out int x)
        {
            return TryCalculateX((widget as TWidget)!, out x);
        }
        bool ILayout2D.TryCalculateY(Widget widget, out int y)
        {
            return TryCalculateY((widget as TWidget)!, out y);
        }
        bool ILayout2D.TryCalculateZ(Widget widget, out int z)
        {
            return TryCalculateZ((widget as TWidget)!, out z);
        }
    }
}
