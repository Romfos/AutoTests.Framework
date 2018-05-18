using AutoTests.Framework.Example.Web.Handlers;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Web.Binding;

namespace AutoTests.Framework.Example.Web.Extensions
{
    public static class ModelExtensions
    {
        public static TModel GetValidationMessages<TModel>(this Binder<TModel> binder, TModel expectedModel)
            where TModel : Model, new()
        {
            var model = expectedModel.Clone(false);
            binder.Trigger<GetValidationMessage>(model);
            return model;
        }
    }
}