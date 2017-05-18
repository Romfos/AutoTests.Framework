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
        private readonly List<IBind> binds = new List<IBind>();
        private readonly TModel model;

        public Binder(TModel model)
        {
            this.model = model;
        }

        public Binder<TModel> Bind<T>(Expression<Func<T>> expression, PageObject pageObject)
        {
            var propertyLink = PropertyLink.Get(expression);
            var bind = new Bind<T>(propertyLink, pageObject);
            binds.Add(bind);
            return this;
        }

        public void SetValue(bool processDiabledProperties = false)
        {
            foreach (var bind in GetBinds(x => x.CanSetValue, processDiabledProperties))
            {
                bind.SetValue();
            }
        }

        public void SetValue(TModel expectedModel)
        {
            foreach (var bind in GetBinds(x => x.CanSetValue, expectedModel))
            {
                bind.SetValue();
            }
        }

        public TModel GetValue(bool processDiabledProperties = false)
        {
            foreach (var bind in GetBinds(x => x.CanGetValue, processDiabledProperties))
            {
                bind.GetValue();
            }
            return model;
        }

        public TModel GetValue(TModel expectedModel)
        {
            foreach (var bind in GetBinds(x => x.CanGetValue, expectedModel))
            {
                bind.GetValue();
            }
            return model;
        }

        public IEnumerable<PropertyLink> GetEnabledProperties(bool expected, bool processDiabledProperties = false)
        {
            foreach (var bind in GetBinds(x => x.CanBeEnabled, processDiabledProperties))
            {
                if (bind.IsEnabled() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetEnabledProperties(bool expected, TModel expectedModel)
        {
            foreach (var bind in GetBinds(x => x.CanBeEnabled, expectedModel))
            {
                if (bind.IsEnabled() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetDisplayedProperties(bool expected, bool processDiabledProperties = false)
        {
            foreach (var bind in GetBinds(x => x.CanBeDisplayed, processDiabledProperties))
            {
                if (bind.IsDisplayed() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetDisplayedProperties(bool expected, TModel expectedModel)
        {
            foreach (var bind in GetBinds(x => x.CanBeDisplayed, expectedModel))
            {
                if (bind.IsDisplayed() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetSelectedProperties(bool expected, bool processDiabledProperties = false)
        {
            foreach (var bind in GetBinds(x => x.CanBeSelected, processDiabledProperties))
            {
                if (bind.IsSelected() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        public IEnumerable<PropertyLink> GetSelectedProperties(bool expected, TModel expectedModel)
        {
            foreach (var bind in GetBinds(x => x.CanBeSelected, expectedModel))
            {
                if (bind.IsSelected() == expected)
                {
                    yield return bind.PropertyLink;
                }
            }
        }

        private IEnumerable<IBind> GetBinds(Func<IBind, bool> condition, bool processDiabledProperties)
        {
            return binds
                .Where(x => !processDiabledProperties || x.PropertyLink.Enabled)
                .Where(condition);
        }

        private IEnumerable<IBind> GetBinds(Func<IBind, bool> condition, TModel expectedModel)
        {
            var names = model.GetModelInfo().GetPropertyLinks().Where(x => x.Enabled).Select(x => x.Name).ToArray();
            return binds.Where(x => names.Contains(x.PropertyLink.Name)).Where(condition);
        }
    }
}