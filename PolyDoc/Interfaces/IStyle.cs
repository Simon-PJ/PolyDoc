using System.Drawing;

namespace PolyDoc.Interfaces
{
    public interface IStyle
    {
        Color Color { set; }

        int Size { set; }

        bool Bold { set; }

        bool Italic { set; }

        bool Underline { set; }

        int SpaceBelow { set; }

        int SpaceAbove { set; }
    }
}
