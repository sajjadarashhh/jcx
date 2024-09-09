using TsCommunicationGenerator.TsInterceptor.TsInterceptorView;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

namespace TsCommunicationGenerator.TsInterceptor
{
    [Generator]
    public class TsInterceptorViewer : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            Compilation compilation = context.Compilation;
            if (compilation is CSharpCompilation)
            {
                if (context.SyntaxReceiver is SyntaxReceiver receiver)
                {
                    foreach (var item in receiver.Classes)
                    {
                        var file = context.AdditionalFiles.FirstOrDefault(s => s.Path == item.GetLocation().SourceTree!.FilePath + ".TCx");
                        if (file is not null)
                        {
                            var data = file.GetText()!.Lines;
                        }
                    }
                }
            }
        }
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }


    }
}
