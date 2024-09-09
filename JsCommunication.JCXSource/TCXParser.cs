using TsCommunication.TCXSource.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.IO;

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
            int openBrace = 
            for (int i = startIndexOfTsExpression; i < fileContent.Count; i++)
            {

            }
            return doc;
        }
    }
}