namespace PolyDoc.Interfaces
{
    public interface ITable
    {
        void AddColumn(int width);

        ITableRow AddRow(int height);

        bool HasBorders { set; }
    }
}
