using System;

namespace Myra.Graphics2D.UI.Properties
{
    public sealed class CustomLocalLayout2D : ILayout2D
    {
        public record struct Context(Widget? Parent, Widget Current);

        public bool IsActive { get; set; }

        public Func<Context, double>? Height { get; set; }
        public Func<Context, double>? Width { get; set; }
        public Func<Context, double>? X { get; set; }
        public Func<Context, double>? Y { get; set; }

        public bool TryCalculateHeight(Widget widget, out int height)
        {
            height = default;

            if (Height is null)
                return false;

            height = (int)Height(new Context(widget.Parent, widget));

            return true;
        }

        public bool TryCalculateWidth(Widget widget, out int width)
        {
            width = default;

            if (Width is null)
                return false;

            width = (int)Width(new Context(widget.Parent, widget));

            return true;
        }

        public bool TryCalculateX(Widget widget, out int x)
        {
            x = default;

            if (X is null)
                return false;

            x = (int)X(new Context(widget.Parent, widget));

            return true;
        }

        public bool TryCalculateY(Widget widget, out int y)
        {
            y = default;

            if (Y is null)
                return false;

            y = (int)Y(new Context(widget.Parent, widget));

            return true;
        }
    }
}
