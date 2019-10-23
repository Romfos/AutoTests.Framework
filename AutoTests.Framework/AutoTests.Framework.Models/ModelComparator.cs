using AutoTests.Framework.Core.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace AutoTests.Framework.Models
{
    public class ModelComparator
    {
        public virtual bool Compare(Model expected, Model actual)
        {
            var expectedProperties = GetPropertyLinks(expected);
            var actualProperties = GetPropertyLinks(actual);
            return Compare(expectedProperties, actualProperties);
        }

        private List<PropertyLink> GetPropertyLinks(Model model)
        {
            return model.GetModelInfo().GetPropertyLinks().Where(x => x.Enabled).ToList();
        }

        private bool Compare(List<PropertyLink> expectedPropertyLinks, List<PropertyLink> actualPropertyLinks)
        {
            foreach(var expectedPropertyLink in expectedPropertyLinks)
            {
                var actualPropertyLink = GetActualPropertyLink(expectedPropertyLink, actualPropertyLinks);
                if(!object.Equals(actualPropertyLink.Value, expectedPropertyLink.Value))
                {
                    return false;
                }
            }
            return true;
        }

        private PropertyLink GetActualPropertyLink(PropertyLink expectedPropertyLink, List<PropertyLink> actualPropertyLinks)
        {
            var actualPropertyLink = actualPropertyLinks.SingleOrDefault(x => x.Name == expectedPropertyLink.Name);
            if(actualPropertyLink == null)
            {
                throw new AutoTestFrameworkException(
                    $"Proprety '{expectedPropertyLink.Name}' doesn't exist in actual model");
            }
            return actualPropertyLink;
        }
    }
}
