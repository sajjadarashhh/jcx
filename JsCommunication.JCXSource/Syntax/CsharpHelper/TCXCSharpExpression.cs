namespace TsCommunication.TCXSource.Syntax.CsharpHelper
{
    public class TCXCSharpExpression : TCXExpression
    {
        public string Expression { get; set; }

        public override TCXBlockLanguage Lang => TCXBlockLanguage.CSharp;
    }
}
