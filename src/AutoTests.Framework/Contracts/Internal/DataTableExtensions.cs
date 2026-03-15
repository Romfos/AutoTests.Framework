namespace AutoTests.Framework.Contracts.Internal;

internal static class DataTableExtensions
{
    extension(string[][] values)
    {
        public IEnumerable<(string, string)> AsNameValueTable()
        {
            if (!(values.Length > 1
                && values.All(x => x.Length == 2)
                && values[0][0] == "Name"
                && values[0][1] == "Value"))
            {
                throw new ArgumentException("Invalid table format. Name-Value table is expected with at least one row");
            }

            return values.Skip(1).Select(x => (x[0], x[1]));
        }

        public IEnumerable<string> AsSingleColumnNameTable()
        {
            if (!(values.Length > 1
                && values.All(x => x.Length == 1)
                && values[0][0] == "Name"))
            {
                throw new ArgumentException("Invalid table format. Single column table with Name header with at least one row is expected");
            }

            return values.Skip(1).Select(x => x[0]);
        }
    }
}
