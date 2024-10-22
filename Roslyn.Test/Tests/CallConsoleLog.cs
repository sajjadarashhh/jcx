
using TsInterceptor.Abstracts.Metadata;

namespace Roslyn.Test.Tests
{
    [TsType]
    public partial class CallConsoleLog
    {
        public string a()
        {
            return "Hello World";
        }
    }
}
