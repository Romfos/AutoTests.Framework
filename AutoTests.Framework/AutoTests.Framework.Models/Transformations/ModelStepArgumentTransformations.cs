using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models.Transformations
{
    public class ModelStepArgumentTransformations<TModel> where TModel : Model, new()
    {
        private readonly ModelTransformationsServiceProvider serviceProvider;

        public ModelStepArgumentTransformations(ModelTransformationsServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        [StepArgumentTransformation]
        public TModel TransformModel(Table table)
        {
            var model = new TModel();
            SetPropertyValues(model, table).Wait();
            return model;
        }

        private async Task SetPropertyValues(TModel model, Table table)
        {
            var propertyLinks = model.GetModelInfo().GetPropertyLinks().ToList();
            foreach (var tableRow in table.Rows)
            {
                await SetPropertyValue(propertyLinks, tableRow);
            }
        }

        private async Task SetPropertyValue(IEnumerable<PropertyLink> propertyLinks, TableRow tableRow)
        {
            var name = tableRow["Name"];
            var value = tableRow["Value"];
            var propertyLink = propertyLinks.Single(x => x.Name == name);
            var propertyValue = await Evaluate(propertyLink.PropertyInfo.PropertyType, value);
            propertyLink.Value = propertyValue;
        }

        private async Task<object> Evaluate(Type type, string code)
        {
            var result = await serviceProvider.PreProcessorServiceProvider.Evaluator.Evaluate<object>(code);
            return Convert.ChangeType(result, type);
        }
    }
}