using TsCommunication.TCXSource.Syntax;
using System.Collections.Generic;

namespace TsCommunication.TCXSource
{
    public class TCXDocument
    {
        public string Path { get; set; }
        public string Class { get; set; }
        public string Scope { get; set; }
        public List<string> Lines { get; set; }
        public List<TCXExpression> Document { get; set; } = new();
    }
}
