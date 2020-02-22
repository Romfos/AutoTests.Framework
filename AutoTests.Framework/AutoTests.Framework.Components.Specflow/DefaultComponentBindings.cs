using AutoTests.Framework.Components.Routes;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.Models.Specflow;
using AutoTests.Framework.PreProcessor;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components.Specflow
{
    [Binding]
    public class DefaultComponentBindings
    {
        private readonly ComponentRouter componentRouter;

        public DefaultComponentBindings(ComponentRouter componentRouter)
        {
            this.componentRouter = componentRouter;
        }

        [When(@"click on '(.*)'")]
        [Given(@"click on '(.*)'")]
        public async Task ClickOn(string query)
        {
            await Resolve<IClick>(query).ClickAsync();
        }

        [When(@"set value '(.*)' in '(.*)'")]
        [Given(@"set value '(.*)' in '(.*)'")]
        public async Task SetValueIn(IExpression expression, string query)
        {
            await Resolve<ISetValue>(query).SetValueAsync(expression);
        }

        [Then(@"'(.*)' should contain '(.*)'")]
        public async Task ThenShouldContain(string query, IExpression expression)
        {
            var isEqual = await Resolve<IEqualTo>(query).EqualToAsync(expression);
            if(!isEqual)
            {
                throw new Exception($"Component '{query}' doesn't contain expected value");
            }
        }

        [Then(@"'(.*)' shouldn't contain '(.*)'")]
        public async Task ThenShouldNotContain(string query, IExpression expression)
        {
            var isEqual = await Resolve<IEqualTo>(query).EqualToAsync(expression);
            if (isEqual)
            {
                throw new Exception($"Component '{query}' contains expected value");
            }
        }

        [Then(@"'(.*)' should be enabled")]
        public async Task ThenShouldBeEnabled(string query)
        {
            var isEnabled = await Resolve<IEnabled>(query).IsEnabledAsync();
            if (!isEnabled)
            {
                throw new Exception($"Component '{query}' should be enabled");
            }
        }

        [Then(@"'(.*)' should be disabled")]
        public async Task ThenShouldBeDisabled(string query)
        {
            var isEnabled = await Resolve<IEnabled>(query).IsEnabledAsync();
            if (isEnabled)
            {
                throw new Exception($"Component '{query}' should be disabled");
            }
        }

        [Then(@"'(.*)' should be selected")]
        public async Task ThenShouldBeSelected(string query)
        {
            var isSelected = await Resolve<ISelected>(query).IsSelectedAsync();
            if (!isSelected)
            {
                throw new Exception($"Component '{query}' should be selected");
            }
        }

        [Then(@"'(.*)' shouldn't be selected")]
        public async Task ThenShouldntBeSelected(string query)
        {
            var isSelected = await Resolve<ISelected>(query).IsSelectedAsync();
            if (isSelected)
            {
                throw new Exception($"Component '{query}' shouldn't be selected");
            }
        }

        [Then(@"'(.*)' should be visible")]
        public async Task ThenShouldBeVisible(string query)
        {
            var isVisiable = await Resolve<IVisible>(query).IsVisibleAsync();
            if (!isVisiable)
            {
                throw new Exception($"Component '{query}' should be visible");
            }
        }

        [Then(@"'(.*)' should be invisible")]
        public async Task ThenShouldBeInvisible(string query)
        {
            var isVisiable = await Resolve<IVisible>(query).IsVisibleAsync();
            if (isVisiable)
            {
                throw new Exception($"Component '{query}' should be invisible");
            }
        }

        [Then(@"'(.*)' should contain following values:")]
        public async Task ThenShouldContainFollowingValues(string query, ModelExpression modelExpression)
        {
            var isMatch = await Resolve<IMatchWith>(query).MatchWithAsync(modelExpression);
            if (!isMatch)
            {
                throw new Exception($"Component '{query}' doesn't match with expected values");
            }
        }

        [Then(@"'(.*)' shouldn't contain following values:")]
        public async Task ThenShouldNotContainFollowingValues(string query, ModelExpression modelExpression)
        {
            var isMatch = await Resolve<IMatchWith>(query).MatchWithAsync(modelExpression);
            if (isMatch)
            {
                throw new Exception($"Component '{query}' match with expected values");
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
