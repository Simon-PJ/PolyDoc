using MigraDoc.DocumentObjectModel;
using PolyDoc.Interfaces;
using Color = System.Drawing.Color;

namespace PolyDoc.Implementations.PDF
{
    public class PdfStyle : IStyle
    {
        private readonly Style _style;

        public PdfStyle(Style style)
        {
            _style = style;
        }

        public Color Color
        {
            set => _style.Font.Color = new MigraDoc.DocumentObjectModel.Color(value.R, value.G, value.B);
        }

        public int Size
        {
            set => _style.Font.Size = value;
        }

        public bool Bold
        {
            set => _style.Font.Bold = value;
        }

        public bool Italic
        {
            set => _style.Font.Italic = value;
        }

        public bool Underline
        {
            set => _style.Font.Underline = value
                ? MigraDoc.DocumentObjectModel.Underline.Single
                : MigraDoc.DocumentObjectModel.Underline.None;
        }

        public int SpaceBelow
        {
            set => _style.ParagraphFormat.SpaceAfter = new Unit(value, UnitType.Millimeter);
        }

        public int SpaceAbove
        {
            set => _style.ParagraphFormat.SpaceBefore = new Unit(value, UnitType.Millimeter);
        }
    }
}
