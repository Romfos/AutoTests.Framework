using AutoTests.Framework.Components;
using AutoTests.Framework.Components.Services;
using Microsoft.Playwright;

namespace Boostrap.Tests.Web.Components;

public abstract class BootstrapComponent : Component
{
	protected IPage Page { get; }

	protected BootstrapComponent(ComponentService componentService, IPage page)
		: base(componentService)
	{
		Page = page;
	}
}
