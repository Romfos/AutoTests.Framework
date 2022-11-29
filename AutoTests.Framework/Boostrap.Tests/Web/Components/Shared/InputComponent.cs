using AutoTests.Framework.Components.Attributes;
using AutoTests.Framework.Components.Services;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace Boostrap.Tests.Web.Components.Shared
{
	public class InputComponent : BootstrapComponent, ISetValue, IEqualTo
	{
		[Primary]
		public string Locator { get; set; }

		public InputComponent(ComponentService componentService, IPage page)
			: base(componentService, page)
		{
		}

		public async Task SetValueAsync(IExpression expression)
		{
			var text = await expression.ExecuteAsync<string>();

			await Page.Locator(Locator).FillAsync(text);
		}

		public async Task<bool> EqualToAsync(IExpression expression)
		{
			var expected = await expression.ExecuteAsync<string>();
			var actual = await Page.Locator(Locator).InputValueAsync();
			return expected == actual;
		}
	}
}
