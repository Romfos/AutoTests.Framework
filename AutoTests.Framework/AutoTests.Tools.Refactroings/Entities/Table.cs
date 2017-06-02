using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class Table
    {
        public List<TableRow> Rows { get; } = new List<TableRow>();
    }
}