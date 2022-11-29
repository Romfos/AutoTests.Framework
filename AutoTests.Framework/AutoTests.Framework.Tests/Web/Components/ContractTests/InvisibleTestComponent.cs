using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

    [Route("invisible test component")]
    public class InvisibleTestComponent : Component, IVisible, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public InvisibleTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public Task<bool> IsVisibleAsync()
        {
            InternalComponentStatus = true;
            return Task.FromResult(false);
        }
    }
