using AutoTests.Framework.Components.Routes;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.PreProcessor;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components.Specflow
{
    [Binding]
    public class DefaultContractsBindings
    {
        private readonly ComponentRouter componentRouter;

        public DefaultContractsBindings(ComponentRouter componentRouter)
        {
            this.componentRouter = componentRouter;
        }

        [When(@"click on '(.*)' component")]
        [Given(@"click on '(.*)' component")]
        public async Task ClickOn(string query)
        {
            await Resolve<IClick>(query).ClickAsync();
        }

        [When(@"set value '(.*)' in '(.*)' component")]
        [Given(@"set value '(.*)' in '(.*)' component")]
        public async Task SetValueIn(IExpression expression, string query)
        {
            await Resolve<ISetValue>(query).SetValue(expression);
        }

        [Then(@"component '(.*)' should contain '(.*)'")]
        public async Task ThenComponentShouldContain(string query, IExpression expression)
        {
            var isEqual = await Resolve<IEqualTo>(query).EqualTo(expression);
            if(!isEqual)
            {
                throw new Exception($"Component '{query}' doesn't contain expected value");
            }
        }

        [Then(@"component '(.*)' should be enabled")]
        public async Task ThenComponentShouldBeEnabled(string query)
        {
            var isEnabled = await Resolve<IEnabled>(query).IsEnabledAsync();
            if (!isEnabled)
            {
                throw new Exception($"Component '{query}' should be enabled");
            }
        }

        [Then(@"component '(.*)' should be disabled")]
        public async Task ThenComponentShouldBeDisabled(string query)
        {
            var isEnabled = await Resolve<IEnabled>(query).IsEnabledAsync();
            if (isEnabled)
            {
                throw new Exception($"Component '{query}' should be disabled");
            }
        }

        [Then(@"component '(.*)' should be selected")]
        public async Task ThenComponentShouldBeSelected(string query)
        {
            var isSelected = await Resolve<ISelected>(query).IsSelectedAsync();
            if (!isSelected)
            {
                throw new Exception($"Component '{query}' should be selected");
            }
        }

        [Then(@"component '(.*)' shouldn't be selected")]
        public async Task ThenComponentShouldntBeSelected(string query)
        {
            var isSelected = await Resolve<ISelected>(query).IsSelectedAsync();
            if (isSelected)
            {
                throw new Exception($"Component '{query}' shouldn't be selected");
            }
        }

        [Then(@"component '(.*)' should be visible")]
        public async Task ThenComponentShouldBeVisible(string query)
        {
            var isVisiable = await Resolve<IVisible>(query).IsVisibleAsync();
            if (!isVisiable)
            {
                throw new Exception($"Component '{query}' should be visible");
            }
        }

        [Then(@"component '(.*)' should be invisible")]
        public async Task ThenComponentShouldBeInvisible(string query)
        {
            var isVisiable = await Resolve<IVisible>(query).IsVisibleAsync();
            if (isVisiable)
            {
                throw new Exception($"Component '{query}' should be invisible");
            }
        }

        private T Resolve<T>(string query) where T : class
        {
            var component = componentRouter.Resolve(RouterRequest.FromQuery(query)) as T;
            if(component == null)
            {
                throw new Exception($"Component must implement '{typeof(T).Name}' contract");
            }
            return component;
        }
    }
}
