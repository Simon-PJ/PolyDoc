using MigraDoc.DocumentObjectModel;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfParagraph : IParagraph
    {
        private readonly Paragraph _paragraph;

        internal PdfParagraph(Paragraph paragraph)
        {
            _paragraph = paragraph;
        }

        public void AddText(string text, string style = null)
        {
            if (string.IsNullOrEmpty(style))
            {
                _paragraph.AddText(text);
            }
            else
            {
                _paragraph.AddFormattedText(text, style);
            }
        }
    }
}
