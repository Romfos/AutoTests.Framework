using AutoTests.Framework.PageObjects;
using AutoTests.Framework.PageObjects.Contracts.PageObjectContracts;

namespace AutoTests.Framework.Tests.Web.ContractsTest
{
    public class ContractsElement1 : Element, ISetValueContract<string>, 
        IGetValueContract<string>, 
        IEnabledContract, 
        ISelectedContract, 
        IVisibleContract, 
        IClickContract
    {
        public string Value { get; set; }

        public ContractsElement1(PageObjectsServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public void SetValue(string value)
        {
            Value = value;
        }

        public string GetValue()
        {
            return Value;
        }

        public bool Enabled { get; } = true;

        public bool Selected { get; } = true;

        public bool Visible { get; } = true;

        public void Click()
        {
            Value = "Click works";
        }
    }
}