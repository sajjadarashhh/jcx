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
                if (classDeclaration.AttributeLists.Any(s => s.Attributes.Any(b => b.Name.ToFullString() == typeof(TsTypeAttribute).FullName)))
                    Classes.Add(classDeclaration);
            }
        }
    }
}
