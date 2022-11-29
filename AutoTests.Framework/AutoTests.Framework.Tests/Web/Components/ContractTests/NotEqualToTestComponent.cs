using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

    [Route("not equal to test component")]
    public class NotEqualToTestComponent : Component, IEqualTo, IInternalComponentStatus
    {
        public bool InternalComponentStatus { get; set; }

        public NotEqualToTestComponent(ComponentService componentService) : base(componentService)
        {
        }

        public async Task<bool> EqualToAsync(IExpression expression)
        {
            InternalComponentStatus = await expression.ExecuteAsync<int>() == 456;
            return false;
        }
    }
