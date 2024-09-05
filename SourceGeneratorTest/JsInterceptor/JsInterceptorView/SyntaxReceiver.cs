using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using JsInterceptor.Abstracts.Metadata;

namespace SourceGeneratorTest.JsInterceptor.JsInterceptorView
{
    public class SyntaxReceiver : ISyntaxReceiver
    {
        public List<ClassDeclarationSyntax> Classes { get; } = [];
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if (syntaxNode is ClassDeclarationSyntax classDeclaration)
            {
                if (classDeclaration.AttributeLists.Any(s => s.Attributes.Any(b => b.Name.ToFullString() == typeof(JsTypeAttribute).FullName)))
                    Classes.Add(classDeclaration);
            }
        }
    }
}
