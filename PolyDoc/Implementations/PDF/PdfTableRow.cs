using MigraDoc.DocumentObjectModel.Tables;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfTableRow : ITableRow
    {
        private readonly Row _row;

        public PdfTableRow(Row row)
        {
            _row = row;
        }

        public IParagraph AddParagraph(int column)
        {
            var cell = _row.Cells[column];
            var paragraph = cell.AddParagraph();
            return new PdfParagraph(paragraph);
        }
    }
}
