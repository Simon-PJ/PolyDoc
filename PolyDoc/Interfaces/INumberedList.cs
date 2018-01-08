namespace PolyDoc.Interfaces
{
    public interface INumberedList
    {
        void AddListItem(string text);

        IParagraph AddListItem();

        INumberedList AddChildLevel();
    }
}
