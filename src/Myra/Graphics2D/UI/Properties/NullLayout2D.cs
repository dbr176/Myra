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
}
