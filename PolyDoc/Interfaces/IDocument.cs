namespace PolyDoc.Interfaces
{
    public interface IDocument
    {
        ISection AddSection();

        IStyle AddStyle(string name);

        void Export(string fileLocation);
    }
}
