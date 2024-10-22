namespace TsCommunication.TCXSource.Syntax.TScriptHelper
{
    public class TCXTScriptExpression : TCXExpression
    {
        public string Expression { get; set; }

        public override TCXBlockLanguage Lang => TCXBlockLanguage.JavaScript;
    }
}
