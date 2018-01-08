using System.Drawing;

namespace PolyDoc.Extensions
{
    internal static class ColorExtensions
    {
        internal static string ToHex(this Color colour)
        {
            return $"#{colour.R:X2}{colour.G:X2}{colour.B:X2}";
        }
    }
}
