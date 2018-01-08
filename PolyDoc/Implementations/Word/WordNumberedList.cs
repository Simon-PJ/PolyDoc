using DocumentFormat.OpenXml.Wordprocessing;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.Word
{
    public class WordNumberedList : INumberedList
    {
        private Document _document;
        private int _level;

        public WordNumberedList(Document document)
        {
            SetFields(document, 0);
        }

        internal WordNumberedList(Document document, int level)
        {
            SetFields(document, level);
        }

        private void SetFields(Document document, int level)
        {
            _document = document;
            _level = level;
        }

        public void AddListItem(string text)
        {
            var paragraph = AddListItem();
            paragraph.AddText(text);
        }

        public IParagraph AddListItem()
        {
            var paragraph = new Paragraph();

            paragraph.Append(
                new ParagraphProperties(
                    new NumberingProperties(
                        new NumberingLevelReference { Val = _level },
                        new NumberingId { Val = 1 })));

            _document.Body.Append(paragraph);

            return new WordParagraph(paragraph);
        }

        public INumberedList AddChildLevel()
        {
            return new WordNumberedList(_document, _level + 1);
        }
    }
}
