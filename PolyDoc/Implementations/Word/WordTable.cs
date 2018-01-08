using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.Word
{
    public class WordTable : ITable
    {
        public void AddColumn(int width)
        {
            throw new System.NotImplementedException();
        }

        public ITableRow AddRow(int height)
        {
            throw new System.NotImplementedException();
        }

        public bool HasBorders { get; set; }
    }
}
