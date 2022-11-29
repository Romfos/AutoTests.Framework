using AutoTests.Framework.Components.Routes;
using AutoTests.Framework.Components.Specflow.Contracts;
using AutoTests.Framework.Components.Specflow.Extensions;
using AutoTests.Framework.Models.Specflow;
using AutoTests.Framework.PreProcessor;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Components.Specflow;

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
            await componentRouter.ResolveContract<IClick>(query).ClickAsync();
        }

        [When(@"set value '(.*)' in '(.*)'")]
        [Given(@"set value '(.*)' in '(.*)'")]
        public async Task SetValueIn(IExpression expression, string query)
        {
            await componentRouter.ResolveContract<ISetValue>(query).SetValueAsync(expression);
        }

        [Then(@"'(.*)' should contain '(.*)'")]
        public async Task ThenShouldContain(string query, IExpression expression)
        {
            var isEqual = await componentRouter.ResolveContract<IEqualTo>(query).EqualToAsync(expression);
            if(!isEqual)
            {
                throw new Exception($"Component '{query}' doesn't contain expected value");
            }
        }

        [Then(@"'(.*)' shouldn't contain '(.*)'")]
        public async Task ThenShouldNotContain(string query, IExpression expression)
        {
            var isEqual = await componentRouter.ResolveContract<IEqualTo>(query).EqualToAsync(expression);
            if (isEqual)
            {
                throw new Exception($"Component '{query}' contains expected value");
            }
        }

        [Then(@"'(.*)' should be enabled")]
        public async Task ThenShouldBeEnabled(string query)
        {
            var isEnabled = await componentRouter.ResolveContract<IEnabled>(query).IsEnabledAsync();
            if (!isEnabled)
            {
                throw new Exception($"Component '{query}' should be enabled");
            }
        }

        [Then(@"'(.*)' should be disabled")]
        public async Task ThenShouldBeDisabled(string query)
        {
            var isEnabled = await componentRouter.ResolveContract<IEnabled>(query).IsEnabledAsync();
            if (isEnabled)
            {
                throw new Exception($"Component '{query}' should be disabled");
            }
        }

        [Then(@"'(.*)' should be selected")]
        public async Task ThenShouldBeSelected(string query)
        {
            var isSelected = await componentRouter.ResolveContract<ISelected>(query).IsSelectedAsync();
            if (!isSelected)
            {
                throw new Exception($"Component '{query}' should be selected");
            }
        }

        [Then(@"'(.*)' shouldn't be selected")]
        public async Task ThenShouldntBeSelected(string query)
        {
            var isSelected = await componentRouter.ResolveContract<ISelected>(query).IsSelectedAsync();
            if (isSelected)
            {
                throw new Exception($"Component '{query}' shouldn't be selected");
            }
        }

        [Then(@"'(.*)' should be visible")]
        public async Task ThenShouldBeVisible(string query)
        {
            var isVisiable = await componentRouter.ResolveContract<IVisible>(query).IsVisibleAsync();
            if (!isVisiable)
            {
                throw new Exception($"Component '{query}' should be visible");
            }
        }

        [Then(@"'(.*)' should be invisible")]
        public async Task ThenShouldBeInvisible(string query)
        {
            var isVisiable = await componentRouter.ResolveContract<IVisible>(query).IsVisibleAsync();
            if (isVisiable)
            {
                throw new Exception($"Component '{query}' should be invisible");
            }
        }

        [Then(@"'(.*)' should contain following values:")]
        public async Task ThenShouldContainFollowingValues(string query, ModelExpression modelExpression)
        {
            var isMatch = await componentRouter.ResolveContract<IMatchWith>(query).MatchWithAsync(modelExpression);
            if (!isMatch)
            {
                throw new Exception($"Component '{query}' doesn't match with expected values");
            }
        }

        [Then(@"'(.*)' shouldn't contain following values:")]
        public async Task ThenShouldNotContainFollowingValues(string query, ModelExpression modelExpression)
        {
            var isMatch = await componentRouter.ResolveContract<IMatchWith>(query).MatchWithAsync(modelExpression);
            if (isMatch)
            {
                throw new Exception($"Component '{query}' match with expected values");
            }
        }
    }
