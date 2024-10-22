using Roslyn.Test.Tests;

namespace Roslyn.Test
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            var aa = new CallConsoleLog();
            HelloFrom("arash");
        }
        static partial void HelloFrom(string name);
    }
}
