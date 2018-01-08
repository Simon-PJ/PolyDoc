using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using PolyDoc.Interfaces;
using Document = DocumentFormat.OpenXml.Wordprocessing.Document;
using DocumentFormat.OpenXml.Packaging;
using Style = DocumentFormat.OpenXml.Wordprocessing.Style;

namespace PolyDoc.Implementations.Word
{
    public class WordDocument : IDocument
    {
        private readonly Document _document;
        private readonly List<WordStyle> _styles;

        public WordDocument()
        {
            _document = new Document { Body = new Body() };

            _styles = new List<WordStyle>();
        }

        public ISection AddSection()
        {
            return new WordSection(_document);
        }

        public IStyle AddStyle(string name)
        {
            var characterStyleName = StyleHelper.GetCharacterStyleName(name);

            var characterStyle = CreateStyle(characterStyleName, StyleValues.Character, name);
            var paragraphStyle = CreateStyle(name, StyleValues.Paragraph, characterStyleName);

            var wordStyle = new WordStyle(new[] { characterStyle, paragraphStyle });
            _styles.Add(wordStyle);

            return wordStyle;
        }

        private Style CreateStyle(string name, StyleValues type, string linkedTo = null)
        {
            var style = new Style
            {
                StyleId = name,
                CustomStyle = true,
                Type = type
            };

            if (!string.IsNullOrEmpty(linkedTo))
            {
                style.Append(new LinkedStyle { Val = linkedTo });
            }

            style.Append(new StyleName { Val = name });

            return style;
        }

        public void Export(string fileLocation)
        {
            using (var doc = WordprocessingDocument.Create(fileLocation, WordprocessingDocumentType.Document))
            {
                var mainPart = doc.AddMainDocumentPart();
                mainPart.Document = _document;

                mainPart.AddNewPart<StyleDefinitionsPart>();
                mainPart.StyleDefinitionsPart.Styles = new Styles(_styles.SelectMany(x => x.Styles));
            }
        }
    }
}
