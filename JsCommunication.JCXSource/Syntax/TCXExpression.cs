using System.Collections.Generic;

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
        public abstract TCXBlockLanguage Lang { get; }
        public List<TCXExpression> Body { get; set; }
    }
}
