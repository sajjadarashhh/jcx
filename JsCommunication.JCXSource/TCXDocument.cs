using TsCommunication.TCXSource.Syntax;
using System.Collections.Generic;

namespace TsCommunication.TCXSource
{
    public class TCXDocument
    {
        public List<string> Lines { get; set; }
        public List<TCXExpression> Document { get; set; }
    }
}
