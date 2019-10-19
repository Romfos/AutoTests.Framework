using System.Collections.Generic;

namespace AutoTests.Framework.PreProcessor.Specflow.Primitives
{
    public class ExpressionTable
    {
        public string[] Headers { get; }
        public Dictionary<string, IExpression>[] Rows { get; }

        public ExpressionTable(string[] headers, Dictionary<string, IExpression>[] rows)
        {
            Headers = headers;
            Rows = rows;
        }
    }
}
