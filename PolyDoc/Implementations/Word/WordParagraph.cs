using DocumentFormat.OpenXml.Wordprocessing;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.Word
{
    public class WordParagraph : IParagraph
    {
        private readonly Paragraph _paragraph;

        public WordParagraph(Paragraph paragraph)
        {
            _paragraph = paragraph;
        }

        public void AddText(string text, string style = null)
        {
            var characterStyleName = StyleHelper.GetCharacterStyleName(style);

            var run = new Run();
            var runProperties = new RunProperties { RunStyle = new RunStyle { Val = characterStyleName } };
            run.Append(runProperties);

            run.Append(new Text(text));

            _paragraph.Append(run);
        }
    }
}
