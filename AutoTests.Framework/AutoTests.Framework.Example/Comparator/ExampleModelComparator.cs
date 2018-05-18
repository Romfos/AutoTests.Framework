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
            return ComparePropertyLinkValidationErrors(expectedLink, actualLink);
        }

        protected Result ComparePropertyLinkValidationErrors(PropertyLink expectedLink, PropertyLink actualLink)
        {
            if (expectedLink.CheckAttribute<ValidationMessageAttribute>())
            {
                if (!actualLink.CheckAttribute<ValidationMessageAttribute>())
                {
                    return new ExpectedAttributeNotFound(actualLink, nameof(ValidationMessageAttribute));
                }
                var expectedMessage = expectedLink.GetAttribute<ValidationMessageAttribute>().Message;
                var actualMesage = actualLink.GetAttribute<ValidationMessageAttribute>().Message;
                if (expectedMessage != actualMesage)
                {
                    return new IncorrectValidationMessage(expectedLink, expectedMessage, actualMesage);
                }
            }
            return null;
        }
    }
}