#if MONOGAME || FNA
using Microsoft.Xna.Framework;
#elif STRIDE
#else
using System.Drawing;
using System.Numerics;
using Matrix = System.Numerics.Matrix3x2;
#endif

namespace Myra.Graphics2D
{
    public readonly record struct Measure(double Value, MeasureType Type = MeasureType.Pixel)
    {
        public static implicit operator Measure(double Value) => new Measure(Value);
        public static implicit operator Measure(float Value) => new Measure(Value);
        public static implicit operator Measure(int Value) => new Measure(Value);
    }
}