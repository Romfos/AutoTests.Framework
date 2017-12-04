using System;
using System.Linq;

namespace AutoTests.Framework.Models.Extensions
{
    public static class ModelExtensions
    {
        public static TModel Clone<TModel>(this TModel baseModel, bool copyValue = true, bool copyStatus = true)
            where TModel : Model, new()
        {
            var newModel = new TModel();
            Iterate(baseModel, newModel, (basePropertyLink, newPropertyLink) =>
            {
                if (copyValue)
                {
                    newPropertyLink.Value = basePropertyLink.Value;
                }
                if (copyStatus)
                {
                    newPropertyLink.Enabled = basePropertyLink.Enabled;
                }
            });
            return newModel;
        }

        private static void Iterate(Model baseModel, Model newModel, Action<PropertyLink, PropertyLink> proc)
        {
            var basePropertyLinks = baseModel.GetModelInfo().GetPropertyLinks();
            var newPropertyLinks = newModel.GetModelInfo().GetPropertyLinks().ToArray();
            foreach (var basePropertyLink in basePropertyLinks)
            {
                foreach (var newPropertyLink in newPropertyLinks)
                {
                    if (basePropertyLink.Name == newPropertyLink.Name)
                    {
                        proc(basePropertyLink, newPropertyLink);
                    }
                }
            }
        }
    }
}