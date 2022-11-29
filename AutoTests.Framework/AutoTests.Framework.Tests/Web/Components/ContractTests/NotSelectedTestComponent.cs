using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

    [Route("not selected test component")]
    public class NotSelectedTestComponent : Component, ISelected, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public NotSelectedTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public Task<bool> IsSelectedAsync()
        {
            InternalComponentStatus = true;
            return Task.FromResult(false);
        }
    }
