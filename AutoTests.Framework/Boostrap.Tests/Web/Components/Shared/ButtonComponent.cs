using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Boostrap.Tests.Web.Components.Shared
{
	public class ButtonComponent : BootstrapComponent, IClick
	{
		[Primary]
		public string Locator { get; set; }

		public ButtonComponent(ComponentService componentService, IPage page)
			: base(componentService, page)
		{
		}

		public async Task ClickAsync()
		{
			await Page.ClickAsync(Locator);
		}
	}
}
