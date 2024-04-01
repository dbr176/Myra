using System;
using System.Diagnostics;

namespace Myra.Graphics2D.UI;

public sealed class ClickHandler : IDisposable
{
    private bool _clickStarted;
    private long _clickStartTime;

    private readonly Widget _widget;

    public ClickHandler(Widget widget)
    {
        widget.TouchDown += Widget_TouchDown;
        widget.TouchUp += Widget_TouchUp;
        widget.TouchLeft += Widget_TouchLeft;

        _widget = widget;
    }

    public event Action<ClickHandlerArgs> Click = _ => { };

    private void Widget_TouchLeft(object? sender, EventArgs e)
    {
        _clickStarted = false;
    }

    private void Widget_TouchUp(object? sender, EventArgs e)
    {
        if (_clickStarted)
        {
            _clickStarted = false;

            var clickMs = (int)(Environment.TickCount64 - _clickStartTime);
            
            Click?.Invoke(
                new ClickHandlerArgs(
                    new TimeSpan(clickMs)));
        }
    }

    private void Widget_TouchDown(object? sender, EventArgs e)
    {
        _clickStarted = true;
        _clickStartTime = Environment.TickCount64;
    }

    public void Dispose()
    {
        _widget.TouchLeft -= Widget_TouchLeft;
        _widget.TouchUp -= Widget_TouchUp;
        _widget.TouchDown -= Widget_TouchDown;
    }
}

public readonly record struct ClickHandlerArgs(TimeSpan ClickTime);
