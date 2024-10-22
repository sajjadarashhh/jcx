using TsCommunication.TCXSource.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;
using TsCommunication.TCXSource.Syntax.CsharpHelper;
using TsCommunication.TCXSource.Exceptions.StructureError;
using TsCommunication.TCXSource.Syntax.TScriptHelper;
using TsCommunication.TCXSource.Syntax.RazorHelper;

namespace TsCommunication.TCXSource
{
    public class TCXParser
    {
        public TCXDocument Parse(List<string> fileContent)
        {
            var doc = new TCXDocument
            {
                Lines = fileContent
            };
            var startIndexOfTsExpression = fileContent.IndexOf("${");
            var startIndexOfCsExpression = fileContent.IndexOf("@{");
            while (fileContent.Any())
            {
                var line = fileContent[0];
                var startOfTs = line.IndexOf("${");
                var startOfCs = line.IndexOf("@{");
                if (startOfTs >= 0)
                {
                    if (startOfTs > 0)
                    {
                        var lineSeprator = line.Substring(0, startOfTs);
                        var lineSepratorSecond = line.Substring(startOfTs);
                        fileContent.RemoveAt(0);
                        doc.Document.Add(new TCXRazorExpression()
                        {
                            Expression = lineSeprator
                        });
                        fileContent.Insert(0, lineSepratorSecond);
                    }
                    fileContent[0] = fileContent[0].Replace("${", "");
                    var result = HandleTs(fileContent);
                    doc.Document.Add(result.Item1);
                    fileContent.RemoveRange(0, result.Item2);
                }
                else if (startOfCs >= 0)
                {
                    if (startOfCs > 0)
                    {
                        var lineSeprator = line.Substring(0, startOfTs);
                        var lineSepratorSecond = line.Substring(startOfTs);
                        fileContent.RemoveAt(0);
                        doc.Document.Add(new TCXRazorExpression()
                        {
                            Expression = lineSeprator
                        });
                        fileContent.Insert(0, lineSepratorSecond);
                    }
                    fileContent[0] = fileContent[0].Replace("@{", "");
                    var result = HandleCSharp(fileContent);
                    doc.Document.Add(result.Item1);
                    fileContent.RemoveRange(0, result.Item2);
                }
                else
                {
                    fileContent.RemoveAt(0);
                    doc.Document.Add(new TCXRazorExpression()
                    {
                        Expression = line
                    });
                }

            }
            return doc;
        }
        private (TCXTScriptExpression, int) HandleTs(List<string> resume)
        {
            TCXTScriptExpression expression = new();
            bool isOpen = true;
            int openBraces = 1;
            int closedBraces = 0;
            int position = 0;
            while (isOpen)
            {
                var line = resume[position++];
                openBraces += line.Count(b => b == '{');
                closedBraces += line.Count(b => b == '}');
                if (openBraces == closedBraces)
                {
                    expression.Expression = string.Join("\r\n", resume.Take(position));
                    expression.Expression = expression.Expression.Remove(expression.Expression.LastIndexOf("}"), 1);
                    break;
                }
                if (position == resume.Count && closedBraces + 1 < openBraces)
                    throw new TCXBlockIsInvalidException();
            }
            return (expression, position);
        }
        private (TCXCSharpExpression, int) HandleCSharp(List<string> resume)
        {
            TCXCSharpExpression expression = new();
            bool isOpen = true;
            int openBraces = 1;
            int closedBraces = 0;
            int position = 0;
            while (isOpen)
            {
                var line = resume[position++];
                openBraces += line.Count(b => b == '{');
                closedBraces += line.Count(b => b == '}');
                if (openBraces == closedBraces)
                {
                    expression.Expression = string.Join("\r\n", resume.Take(position));
                    expression.Expression = expression.Expression.Remove(expression.Expression.LastIndexOf("}"), 1);
                    break;
                }
                if (position == resume.Count && closedBraces + 1 < openBraces)
                    throw new TCXBlockIsInvalidException();
            }
            return (expression, position);
        }
    }
}