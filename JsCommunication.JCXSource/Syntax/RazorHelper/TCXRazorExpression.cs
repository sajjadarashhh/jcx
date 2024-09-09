using System.Collections.Generic;

namespace TsCommunication.TCXSource.Syntax.RazorHelper
{
    public class TCXRazorExpression : TCXExpression
    {
        public string Expression { get; set; }
        public List<TCXExpression> InnerExpression { get; set; }
    }
}
