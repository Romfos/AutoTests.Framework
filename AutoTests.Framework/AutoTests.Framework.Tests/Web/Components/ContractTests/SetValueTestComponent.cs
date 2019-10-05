using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests
{
    [Route("set value test component")]
    public class SetValueTestComponent : Component, ISetValue, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public SetValueTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public async Task SetValue(IExpression expression)
        {
            InternalComponentStatus = await expression.ExecuteAsync<int>() == 123;
        }
    }
}
