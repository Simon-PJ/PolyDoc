using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfTable : ITable
    {
        private readonly Table _table;

        public PdfTable(Table table)
        {
            _table = table;
        }

        public void AddColumn(int width)
        {
            var column = _table.AddColumn();
            column.Width = width;
        }

        public ITableRow AddRow(int height)
        {
            var row = _table.AddRow();
            row.Height = row.Height;
            return new PdfTableRow(row);
        }

        public bool HasBorders
        {
            set => _table.Borders = new Borders { Style = value ? BorderStyle.Single : BorderStyle.None };
        }
    }
}
