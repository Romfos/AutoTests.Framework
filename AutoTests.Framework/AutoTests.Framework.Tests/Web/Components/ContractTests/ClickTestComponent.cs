using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

    [Route("click test component")]
    public class ClickTestComponent : Component, IClick, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public ClickTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public Task ClickAsync()
        {
            InternalComponentStatus = true;
            return Task.CompletedTask;
        }
    }
