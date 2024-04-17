namespace Myra.Graphics2D.UI.Properties
{
    public sealed class NullLayout2D : ILayout2D
    {
        public static readonly ILayout2D Instance = new NullLayout2D();

        private NullLayout2D() { }

        public bool IsActive => false;

        public bool TryCalculateHeight(Widget widget, out int height)
        {
            height = default;
            return false;
        }

        public bool TryCalculateWidth(Widget widget, out int width)
        {
            width = default;
            return false;
        }

        public bool TryCalculateX(Widget widget, out int x)
        {
            x = default;
            return false;
        }

        public bool TryCalculateY(Widget widget, out int y)
        {
            y = default;
            return false;
        }

        public bool TryCalculateZ(Widget widget, out int z)
        {
            z = default;
            return false;
        }
    }

    public abstract class Layout2D<T> : ILayout2D<T>
        where T : Widget
    {
        public bool IsActive => true;

        public virtual bool TryCalculateHeight(T widget, out int height)
        {
            height = default;
            return false;
        }

        public virtual bool TryCalculateWidth(T widget, out int width)
        {
            width = default;
            return false;
        }

        public virtual bool TryCalculateX(T widget, out int x)
        {
            x = 0; return false;
        }

        public virtual bool TryCalculateY(T widget, out int y)
        {
            y = 0; return false;
        }

        public virtual bool TryCalculateZ(T widget, out int z)
        {
            z = 0; return false;
        }
    }
}