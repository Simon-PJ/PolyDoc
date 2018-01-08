namespace PolyDoc.Implementations.Word
{
    class StyleHelper
    {
        internal const string CharacterStyleSuffix = "char";

        internal static string GetCharacterStyleName(string styleName)
        {
            return $"{styleName}{CharacterStyleSuffix}";
        }

        internal static int ConvertFontSize(int fontSize)
        {
            return fontSize * 2;
        }
    }
}
