using DocumentFormat.OpenXml.Wordprocessing;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.Word
{
    public class WordSection : ISection
    {
        private readonly Document _document;

        public WordSection(Document document)
        {
            _document = document;
        }

        public IParagraph AddParagraph(string style = null)
        {
            var paragraph = new Paragraph();
            _document.Body.Append(paragraph);

            if (!string.IsNullOrEmpty(style))
            {
                paragraph.Append(
                    new ParagraphProperties(
                        new ParagraphStyleId { Val = style }));

            }

            return new WordParagraph(paragraph);
        }

        public ITable AddTable()
        {
            throw new System.NotImplementedException();
        }

        public INumberedList AddNumberedList()
        {
            return new WordNumberedList(_document);
        }
    }
}
