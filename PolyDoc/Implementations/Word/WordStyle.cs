using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using PolyDoc.Extensions;
using PolyDoc.Interfaces;
using Color = System.Drawing.Color;

namespace PolyDoc.Implementations.Word
{
    public class WordStyle : IStyle
    {
        private readonly List<Style> _styles;

        public WordStyle(Style style)
        {
            style.StyleRunProperties = new StyleRunProperties();
            _styles = new List<Style> { style };
        }

        public WordStyle(IEnumerable<Style> linkedStyles)
        {
            _styles = linkedStyles.ToList();

            foreach (var style in _styles)
            {
                style.StyleRunProperties = new StyleRunProperties();
            }
        }

        public Color Color
        {
            set
            {
                var color = new DocumentFormat.OpenXml.Wordprocessing.Color
                {
                    Val = value.ToHex()
                };
                _styles.ForEach(x => x.StyleRunProperties.Append(color));
            }
        }

        public int Size
        {
            set => _styles.ForEach(x => x.StyleRunProperties.Append(new FontSize { Val = StyleHelper.ConvertFontSize(value).ToString() }));
        }

        public bool Bold
        {
            set
            {
                if (value)
                {
                    _styles.ForEach(x => x.StyleRunProperties.Append(new Bold()));
                }
                else
                {
                    _styles.ForEach(x => x.StyleRunProperties.RemoveAllChildren<Bold>());
                }
            }
        }

        public bool Italic
        {
            set
            {
                if (value)
                {
                    _styles.ForEach(x => x.StyleRunProperties.Append(new Italic()));
                }
                else
                {
                    _styles.ForEach(x => x.StyleRunProperties.RemoveAllChildren<Italic>());
                }
            }
        }

        public bool Underline
        {
            set
            {
                if (value)
                {
                    _styles.ForEach(x => x.StyleRunProperties.Append(new Underline()));
                }
                else
                {
                    _styles.ForEach(x => x.StyleRunProperties.RemoveAllChildren<Underline>());
                }
            }
        }

        public int SpaceBelow
        {
            set => System.Diagnostics.Debug.Write("To be implemented");
        }

        public int SpaceAbove
        {
            set => System.Diagnostics.Debug.Write("To be implemented");
        }

        internal IEnumerable<Style> Styles => _styles;
    }
}
