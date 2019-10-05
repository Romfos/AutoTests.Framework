using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests
{
    [Route("visible test component")]
    public class VisibleTestComponent : Component, IVisible, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public VisibleTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public Task<bool> IsVisibleAsync()
        {
            InternalComponentStatus = true;
            return Task.FromResult(true);
        }
    }
}
