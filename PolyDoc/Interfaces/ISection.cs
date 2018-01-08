namespace PolyDoc.Interfaces
{
    public interface ISection
    {
        IParagraph AddParagraph(string style = null);

        ITable AddTable();

        INumberedList AddNumberedList();
    }
}
