using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor.Specflow.Primitives;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests
{
    [Route("match with test component")]
    public class MatchWithTestComponent : Component, IMatchWith, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public MatchWithTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public async Task<bool> MatchWith(ExpressionTable expectedValues)
        {
            InternalComponentStatus = await expectedValues.Rows[0]["Name"].ExecuteAsync<string>() == "AA"
                && await expectedValues.Rows[0]["Value"].ExecuteAsync<string>() == "123"
                && await expectedValues.Rows[1]["Name"].ExecuteAsync<string>() == "BB"
                && await expectedValues.Rows[1]["Value"].ExecuteAsync<string>() == "456";

            return true;
        }
    }
}
