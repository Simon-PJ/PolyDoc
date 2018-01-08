using MigraDoc.DocumentObjectModel;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfNumberedList : INumberedList
    {
        private const int Indentation = 30;

        private Section _section;
        private string _parentNumbering;
        private int _level;
        private int _itemCount;

        public PdfNumberedList(Section section)
        {
            SetFields(section, string.Empty, 0);
        }

        internal PdfNumberedList(Section section, string parentNumbering, int level)
        {
            SetFields(section, parentNumbering, level);
        }

        private void SetFields(Section section, string parentNumbering, int level)
        {
            _section = section;
            _parentNumbering = parentNumbering;
            _level = level;
        }

        public void AddListItem(string text)
        {
            var paragraph = AddListItem();
            paragraph.AddText(text);
        }

        public IParagraph AddListItem()
        {
            _itemCount++;

            var table = _section.AddTable();
            var marginColumn = table.AddColumn();
            marginColumn.Width = Indentation * (_level + 1);
            marginColumn.Format.Alignment = ParagraphAlignment.Right;

            var pageSetup = _section.Document.DefaultPageSetup;

            var contentColumn = table.AddColumn();
            contentColumn.Width = pageSetup.PageWidth - marginColumn.Width - pageSetup.LeftMargin - pageSetup.RightMargin;
            contentColumn.Format.Alignment = ParagraphAlignment.Left;

            var row = table.AddRow();
            row.Cells[0].AddParagraph(GetNumberString());
            var paragraph = row.Cells[1].AddParagraph();

            return new PdfParagraph(paragraph);
        }

        private string GetNumberString()
        {
            return $"{_parentNumbering}{(!string.IsNullOrEmpty(_parentNumbering) ? "." : string.Empty)}{_itemCount}";
        }

        public INumberedList AddChildLevel()
        {
            return new PdfNumberedList(_section, GetNumberString(), _level + 1);
        }
    }
}
