using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Models.Comparator.Results;

namespace AutoTests.Framework.Models.Comparator
{
    public class ModelComparator
    {
        public IEnumerable<Result> Compare<T>(T expected, T actual)
            where T : Model
        {
            var expectedPropertyLinks = GetPropertyLink(expected);
            var actualPropertyLinks = GetPropertyLink(actual);
            return Compare(expectedPropertyLinks, actualPropertyLinks);
        }

        private PropertyLink[] GetPropertyLink(Model model)
        {
            return model.GetModelInfo().GetPropertyLinks().Where(x => x.Enabled).ToArray();
        }

        private IEnumerable<Result> Compare(PropertyLink[] expectedLinks, PropertyLink[] actualLinks)
        {
            foreach (var expectedLink in expectedLinks)
            {
                var result = Compare(expectedLink, actualLinks);
                if (result != null)
                {
                    yield return result;
                }
            }
        }

        private Result Compare(PropertyLink expectedLink, PropertyLink[] actualLinks)
        {
            foreach (var actualLink in actualLinks)
            {
                if (expectedLink.Name == actualLink.Name)
                {
                    return Compare(expectedLink, actualLink);
                }
            }
            return new ActualNotFound(expectedLink);
        }

        protected virtual Result Compare(PropertyLink expectedLink, PropertyLink actualLink)
        {
            if (!Compare(expectedLink.Value, actualLink.Value))
            {
                return new IncorrectValue(expectedLink, actualLink);
            }
            return null;
        }

        private bool Compare(object expected, object actual)
        {
            return expected.Equals(actual);
        }
    }
}