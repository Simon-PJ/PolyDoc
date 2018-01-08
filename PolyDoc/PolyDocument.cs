using System;
using PolyDoc.Implementations.PDF;
using PolyDoc.Implementations.Word;
using PolyDoc.Interfaces;

namespace PolyDoc
{
    public class PolyDocument
    {
        public static IDocument NewDocument(DocumentType type)
        {
            IDocument document = null;

            switch (type)
            {
                case DocumentType.Pdf:
                    document = new PdfDocument();
                    break;
                case DocumentType.Word:
                    document = new WordDocument();
                    break;
            }

            return document;
        }
    }
}
