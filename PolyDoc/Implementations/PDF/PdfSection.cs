using MigraDoc.DocumentObjectModel;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfSection : ISection
    {
        private readonly Section _section;

        internal PdfSection(Section section)
        {
            _section = section;
        }

        public IParagraph AddParagraph(string style = null)
        {
            var paragraph = _section.AddParagraph();

            if (!string.IsNullOrEmpty(style))
            {
                paragraph.Style = style;
            }

            return new PdfParagraph(paragraph);
        }

        public ITable AddTable()
        {
            var table = _section.AddTable();
            return new PdfTable(table);
        }

        public INumberedList AddNumberedList()
        {
            return new PdfNumberedList(_section);
        }
    }
}
