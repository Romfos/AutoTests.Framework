using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Tools.Refactroings.Entities
{
    public class TableRow
    {
        public List<TableItem> Items { get; } = new List<TableItem>();
        
        public TableItem GetItemByName(string name)
        {
            return Items.Single(x => x.Name == name);
        }
    }
}