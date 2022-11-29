using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.PreProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace AutoTests.Framework.Models.Specflow;

    public class ModelTransformationTypedBindings<TModel>
        where TModel: Model, new()
    {
        private readonly IPreProcessor preProcessor;

        public ModelTransformationTypedBindings(IPreProcessor preProcessor)
        {
            this.preProcessor = preProcessor;
        }

        [StepArgumentTransformation]
        public TModel GetModel(Table table)
        {
            var model = new TModel();
            var propertyLinks = model.GetModelInfo().GetPropertyLinks().ToList();

            foreach (var tableRow in table.Rows)
            {
                var name = tableRow["Name"];
                var value = tableRow["Value"];
                SetPropertyValueAndRemoveFromList(propertyLinks, name, value);
            }

            foreach(var propertyLink in propertyLinks)
            {
                propertyLink.Enabled = false;
            }

            return model;
        }

        [StepArgumentTransformation]
        public IEnumerable<TModel> GetModels(Table table)
        {
            foreach(var tableRow in table.Rows)
            {
                var model = new TModel();
                var propertyLinks = model.GetModelInfo().GetPropertyLinks().ToList();
                
                foreach(var tableCell in tableRow)
                {
                    var name = tableCell.Key;
                    var value = tableCell.Value;
                    SetPropertyValueAndRemoveFromList(propertyLinks, name, value);
                }

                yield return model;
            }
        }

        [StepArgumentTransformation]
        public List<TModel> GetModelList(Table table)
        {
            return GetModels(table).ToList();
        }

        [StepArgumentTransformation]
        public TModel[] GetModelArray(Table table)
        {
            return GetModels(table).ToArray();
        }

        private void SetPropertyValueAndRemoveFromList(List<PropertyLink> propertyLinks, string propertyName, string expession)
        {
            var propertyLink = PullPropertyLink(propertyLinks, propertyName);
            var value = preProcessor.ExecuteAsync<object>(expession).Result;
            var propertyValue = Convert.ChangeType(value, propertyLink.PropertyInfo.PropertyType);
            propertyLink.Value = propertyValue;
        }

        private PropertyLink PullPropertyLink(List<PropertyLink> propertyLinks, string propertyName)
        {
            var propertyLink = propertyLinks.SingleOrDefault(x => x.Name == propertyName);
            if (propertyLink == null)
            {
                throw new AutoTestFrameworkException(
                    $"Model '{typeof(TModel).FullName}' doesn't contain property with name '{propertyName}'");
            }
            propertyLinks.Remove(propertyLink);
            return propertyLink;
        }
    }
