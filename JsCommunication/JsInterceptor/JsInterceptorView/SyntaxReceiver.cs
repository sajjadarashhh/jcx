using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using TsInterceptor.Abstracts.Metadata;

namespace TsCommunicationGenerator.TsInterceptor.TsInterceptorView
{
    public class SyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Classes { get; } = [];
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                if (classDeclaration.AttributeLists.Any(s => s.Attributes.Any(b =>
                {
                    var name = b.Name.GetText()+"Attribute";
                    return name.ToString() == typeof(TsTypeAttribute).Name;
                }
                )))
                    Classes.Add(classDeclaration);
            }
        }
    }
}
