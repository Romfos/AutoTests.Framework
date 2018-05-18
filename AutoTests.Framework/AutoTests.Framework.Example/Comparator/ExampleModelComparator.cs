using AutoTests.Framework.Example.Comparator.Results;
using AutoTests.Framework.Example.Web.Attributes;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Comparator;
using AutoTests.Framework.Models.Comparator.Results;

namespace AutoTests.Framework.Example.Comparator
{
    public class ExampleModelComparator : ModelComparator
    {
        protected override Result CompareCustomAttributes(PropertyLink expectedLink, PropertyLink actualLink)
        {
            return CompareValidationErrors(expectedLink, actualLink);
        }

        protected Result CompareValidationErrors(PropertyLink expectedLink, PropertyLink actualLink)
        {
            if (expectedLink.CheckAttribute<ValidationMessageAttribute>())
            {
                var expectedMessage = GetValidationMessage(expectedLink);
                var actualMesage = GetValidationMessage(actualLink);
                if (expectedMessage != actualMesage)
                {
                    return new IncorrectValidationMessage(expectedLink, expectedMessage, actualMesage);
                }
            }
            return null;
        }

        private string GetValidationMessage(PropertyLink propertyLink)
        {
            return propertyLink.CheckAttribute<ValidationMessageAttribute>()
                ? propertyLink.GetAttribute<ValidationMessageAttribute>().Message
                : null;
        }
    }
}