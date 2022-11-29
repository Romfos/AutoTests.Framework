using System.Threading.Tasks;
using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Routes.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.Models.Specflow;
using AutoTests.Framework.Tests.Models.MismatchTest;

namespace AutoTests.Framework.Tests.Web.Components.ContractTests;

[Route("mismatch test component")]
public class MismatchTestComponent : Component, IMatchWith, IInternalComponentStatus
{
    public bool InternalComponentStatus { get; set; }

    public MismatchTestComponent(ComponentService componentService) : base(componentService)
    {
    }

    public Task<bool> MatchWithAsync(ModelExpression expression)
    {
        var expected = new MismatchTestModel
        {
            AA = 123,
            BB = 456
        };

        InternalComponentStatus = expression.Compare(expected);

        return Task.FromResult(false);
    }
}
