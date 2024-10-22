using System;
using System.Linq;

namespace TsCommunicationGenerator.TsInterceptor.SourceParser
{
    public class TCXParse
    {
        public string[] Lines { get; }
        public TCXParse(string[] lines)
        {
            Lines = lines;
        }

        public string TsCode()
        {
            throw new NotImplementedException();
        }
    }
}
