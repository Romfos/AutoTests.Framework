using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Extensions;
using AutoTests.Framework.Web.Binding;
using AutoTests.Framework.Web.Common.Handlers;

namespace AutoTests.Framework.Web.Common.Extensions
{
    public static class BinderExtensions
    {
        public static void Click<TModel>(this Binder<TModel> binder, TModel model)
            where TModel : Model
        {
            binder.Trigger<Click>(model);
        }

        public static void SetValue<TModel>(this Binder<TModel> binder, TModel model)
            where TModel : Model
        {
            binder.Trigger<SetValue>(model);
        }

        public static TModel GetValue<TModel>(this Binder<TModel> binder, TModel expectedModel)
            where TModel : Model, new()
        {
            var model = expectedModel.Clone(false);
            binder.Trigger<GetValue>(model);
            return model;
        }

        public static TModel GetValue<TModel>(this Binder<TModel> binder)
            where TModel : Model, new()
        {
            var model = new TModel();
            binder.Trigger<GetValue>(model);
            return model;
        }

        public static IEnumerable<PropertyLink> GetDisplayedProperties<TModel>(this Binder<TModel> binder, TModel model)
            where TModel : Model
        {
            return binder.Trigger<Displayed>(model).Cast<PropertyLink>();
        }

        public static IEnumerable<PropertyLink> GetEnabledProperties<TModel>(this Binder<TModel> binder, TModel model)
            where TModel : Model
        {
            return binder.Trigger<Enabled>(model).Cast<PropertyLink>();
        }

        public static IEnumerable<PropertyLink> GetSelectedProperties<TModel>(this Binder<TModel> binder, TModel model)
            where TModel : Model
        {
            return binder.Trigger<Selected>(model).Cast<PropertyLink>();
        }
    }
}