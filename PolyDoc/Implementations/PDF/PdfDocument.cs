using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PolyDoc.Interfaces;

namespace PolyDoc.Implementations.PDF
{
    public class PdfDocument : IDocument
    {
        private readonly Document _document;

        public PdfDocument()
        {
            _document = new Document();
        }

        public ISection AddSection()
        {
            var section = _document.AddSection();
            return new PdfSection(section);
        }

        public IStyle AddStyle(string name)
        {
            var style = _document.AddStyle(name, "normal");
            return new PdfStyle(style);
        }

        public void Export(string fileLocation)
        {
            var renderer = new PdfDocumentRenderer(true) {Document = _document};
            renderer.RenderDocument();
            renderer.PdfDocument.Save(fileLocation);
        }
    }
}
