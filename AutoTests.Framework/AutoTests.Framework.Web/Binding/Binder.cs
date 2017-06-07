using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoTests.Framework.Models;

namespace AutoTests.Framework.Web.Binding
{
    public class Binder<TModel>
        where TModel : Model, new()
    {
        private readonly List<Func<TModel, IBind>> bindings = new List<Func<TModel, IBind>>();

        public Binder<TModel> Bind<T>(Expression<Func<TModel, T>> expression, PageObject pageObject)
        {
            bindings.Add(model =>
            {
                var propertyLink = PropertyLink.Get(model, expression);
                return new Bind<T>(propertyLink, pageObject);
            });
            return this;
        }

        private IEnumerable<IBind> BindModel(TModel model)
        {
            return bindings.Select(gettter => gettter(model));
        }

        public void SetValue(TModel model, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(model, processDisabledProperties, x => x.CanSetValue))
            {
                bind.SetValue();
            }
        }

        public TModel GetValue(bool processDisabledProperties = false)
        {
            var actual = new TModel();
            foreach (var bind in GetConditionalBinds(actual, processDisabledProperties, x => x.CanGetValue))
            {
                bind.GetValue();
            }
            return actual;
        }

        public TModel GetValue(TModel expected)
        {
            var actual = new TModel();
            foreach (var bind in GetExpectedBinds(actual, expected, x => x.CanGetValue))
            {
                bind.GetValue();
            }
            return actual;
        }

        public IEnumerable<PropertyLink> GetEnabledProperties(bool value = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(new TModel(), processDisabledProperties, x => x.CanBeEnabled))
            {
                if (bind.IsEnabled() == value)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetSelectedProperties(bool value = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(new TModel(), processDisabledProperties, x => x.CanBeSelected))
            {
                if (bind.IsSelected() == value)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetDisplayedProperties(bool value = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(new TModel(), processDisabledProperties, x => x.CanBeDisplayed))
            {
                if (bind.IsDisplayed() == value)
                {
                    yield return bind.PropertyLink;
                }
            }
        }


        public IEnumerable<PropertyLink> GetEnabledProperties(TModel model, bool expected = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(model, processDisabledProperties, x => x.CanBeEnabled))
            {
                if (bind.IsEnabled() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetSelectedProperties(TModel model, bool value = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(model, processDisabledProperties, x => x.CanBeSelected))
            {
                if (bind.IsSelected() == value)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetDisplayedProperties(TModel model, bool value = true, bool processDisabledProperties = false)
        {
            foreach (var bind in GetConditionalBinds(model, processDisabledProperties, x => x.CanBeDisplayed))
            {
                if (bind.IsDisplayed() == value)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        private IEnumerable<IBind> GetConditionalBinds(TModel model, bool processDisabledProperties, Func<IBind, bool> condition)
        {
            return BindModel(model).Where(x => !processDisabledProperties || x.PropertyLink.Enabled).Where(condition);
        }

        private IEnumerable<IBind> GetExpectedBinds(TModel actual, TModel expected, Func<IBind, bool> condition)
        {
            var expectedProperties = expected.GetModelInfo().GetPropertyLinks().Where(x => x.Enabled).ToArray();

            return BindModel(actual).Where(x => expectedProperties.Contains(x.PropertyLink)).Where(condition);
        }
    }
}