using System.Collections.Generic;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class TableRow
    {
        public List<TableItem> Items { get; } = new List<TableItem>();
    }
}