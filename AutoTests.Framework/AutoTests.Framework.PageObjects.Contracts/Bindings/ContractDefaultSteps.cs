using System;
using System.Linq;
using System.Threading.Tasks;
using AutoTests.Framework.PageObjects.Contracts.PageObjectContracts;
using AutoTests.Framework.PageObjects.Provider;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.PageObjects.Contracts.Bindings
{
    [Binding]
    public class ContractDefaultSteps
    {
        private readonly ContractsServiceProvider serviceProvider;

        public ContractDefaultSteps(ContractsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [When(@"set '(.*)' value in '(.*)'")]
        public async Task SetValueIn(string expression, string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var value = await serviceProvider.PreProcessor.Evaluator.Evaluate<object>(expression);

            var method = pageObject.GetType().GetMethod(nameof(ISetValueContract<object>.SetValue));
            var convertedValue = Convert.ChangeType(value, method.GetParameters().Single().ParameterType);
            method.Invoke(pageObject, new[] {convertedValue});
        }

        [When(@"click on '(.*)'")]
        public void WhenClickOn(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as IClickContract;
            contract.Click();
        }

        [Then(@"value in '(.*)' should be equal '(.*)'")]
        public async Task ThenValueInShouldBeEqual(string query, string expression)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var value = await serviceProvider.PreProcessor.Evaluator.Evaluate<object>(expression);

            var method = pageObject.GetType().GetMethod(nameof(IGetValueContract<object>.GetValue));
            var expected = Convert.ChangeType(value, method.ReturnType);
            var actual = method.Invoke(pageObject, null);

            if (!expected.Equals(actual))
            {
                throw new Exception($"Values are not equal. Expected {expected}. Actual {actual}");
            }
        }

        [Then(@"'(.*)' should be enabled")]
        public void ThenShouldBeEnabled(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as IEnabledContract;

            if (!contract.Enabled)
            {
                throw new Exception($"Page object '{query}' is disabled");
            }
        }

        [Then(@"'(.*)' should not be enabled")]
        public void ThenShouldNotBeEnabled(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as IEnabledContract;

            if (contract.Enabled)
            {
                throw new Exception($"Page object '{query}' is enabled");
            }
        }

        [Then(@"'(.*)' should be visible")]
        public void ThenShouldBeVisible(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as IVisibleContract;

            if (!contract.Visible)
            {
                throw new Exception($"Page object '{query}' is invisible");
            }
        }

        [Then(@"'(.*)' should not be visible")]
        public void ThenShouldNotBeVisible(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as IVisibleContract;

            if (contract.Visible)
            {
                throw new Exception($"Page object '{query}' is visible");
            }
        }

        [Then(@"'(.*)' should be selected")]
        public void ThenShouldBeSelected(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as ISelectedContract;

            if (!contract.Selected)
            {
                throw new Exception($"Page object '{query}' is not selected");
            }
        }

        [Then(@"'(.*)' should not be selected")]
        public void ThenShouldNotBeSelected(string query)
        {
            var pageObjectQuery = new PageObjectQuery(query);
            var pageObject = serviceProvider.PageObjectProvider.PageObjectProvider.Request(pageObjectQuery);
            var contract = pageObject as ISelectedContract;

            if (contract.Selected)
            {
                throw new Exception($"Page object '{query}' is selected");
            }
        }
    }
}