namespace TsCommunication.TCXSource.Syntax
{
    public enum TCXBlockLanguage
    {
        Razor,//<-- default
        CSharp,
        JavaScript
    }
    public abstract class TCXExpression
    {
        public TCXBlockLanguage Lang { get; set; }
        public TCXExpression Body { get; set; }
    }
}
