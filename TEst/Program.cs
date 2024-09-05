using TEst.Tests;

namespace TEst
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
