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
    public enum MeasureType
	{
		Pixel,
		PercentToParent,
		PercentToScreen
	}
}