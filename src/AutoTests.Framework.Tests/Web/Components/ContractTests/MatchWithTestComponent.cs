using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.Models.Specflow;
using AutoTests.Framework.Tests.Models.MatchWithTest;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

[Route("match with test component")]
public class MatchWithTestComponent : Component, IMatchWith, IInternalComponentStatus
{
    public bool InternalComponentStatus { get; set; }

    public MatchWithTestComponent(ComponentService componentService) : base(componentService)
    {
    }

    public Task<bool> MatchWithAsync(ModelExpression expression)
    {
        var expected = new MatchWithTestModel
        {
            AA = 123,
            BB = 456
        };

        InternalComponentStatus = expression.Compare(expected);

        return Task.FromResult(true);
    }
}
