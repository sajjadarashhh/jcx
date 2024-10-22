using TsCommunicationGenerator.TsInterceptor.TsInterceptorView;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;
using TsCommunicationGenerator.TsInterceptor.SourceParser;
using TsCommunication.TCXSource;
using System.Collections.Generic;
using TsCommunication.TCXSource.Syntax;
using TsCommunication.TCXSource.Syntax.CsharpHelper;
using TsCommunication.TCXSource.Syntax.TScriptHelper;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace TsCommunicationGenerator.TsInterceptor
{
    [Generator]
    public class TsInterceptorViewer : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Compilation compilation = context.Compilation;
            List<TCXDocument> documents = new();
            if (compilation is CSharpCompilation)
            {
                if (context.SyntaxReceiver is SyntaxReceiver receiver)
                {
                    foreach (var item in receiver.Classes)
                    {
                        var file = context.AdditionalFiles.FirstOrDefault(s => s.Path == item.GetLocation().SourceTree!.FilePath + ".tcx");
                        if (file is not null)
                        {
                            var datas = file.GetText();
                            var data = file.GetText()!.Lines.Select(a => a.ToString()).ToList();
                            var doc = new TCXParser().Parse(data.ToList());
                            doc.Path = file.Path;
                            doc.Class = item.Identifier.Text;
                            doc.Scope = item.Ancestors()
        .OfType<NamespaceDeclarationSyntax>()
        .FirstOrDefault().Name.ToString();
                            documents.Add(doc);
                        }
                    }
                }
            }
            foreach (var item in documents)
            {
                var cSharp = item.Document.Where(a => a.Lang == TCXBlockLanguage.CSharp).Select(a => (TCXCSharpExpression)a).ToList();
                var tScript = item.Document.Where(a => a.Lang == TCXBlockLanguage.JavaScript).Select(a => (TCXTScriptExpression)a).ToList();
                foreach (var node in cSharp)
                {
                    context.AddSource($"{item.Class}.CodeGen.g.cs", $@"
                        namespace {item.Scope};
                        public partial class {item.Class}
                        {{
                              public void Generated(){{ {node.Expression} }}
                        }}");
                }
            }
        }
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }


    }
}
