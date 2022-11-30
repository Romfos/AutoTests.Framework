using AutoTests.Framework.Core;
using TechTalk.SpecFlow;
using AutoTests.Framework.Core.Extensions;
using System.Collections.Generic;

namespace AutoTests.Framework.Models.Specflow;

public class ModelExpression
{
    private readonly IContainer container;
    private readonly ModelComparator modelComparator;
    private readonly Table table;

    public ModelExpression(IContainer container, ModelComparator modelComparator, Table table)
    {
        this.container = container;
        this.modelComparator = modelComparator;
        this.table = table;
    }

    public bool Compare<TModel>(TModel actual) where TModel : Model, new()
    {
        var expected = GetModel<TModel>();
        return modelComparator.Compare(actual, expected);
    }

    public bool Compare<TModel>(IEnumerable<TModel> actualModels) where TModel : Model, new()
    {
        var expectedModels = GetModels<TModel>();
        return modelComparator.Compare(expectedModels, actualModels);
    }

    public TModel GetModel<TModel>() where TModel : Model, new()
    {
        var transformations = container.Resolve<ModelTransformationTypedBindings<TModel>>();
        var model = transformations.GetModel(table);
        return model;
    }

    public IEnumerable<TModel> GetModels<TModel>() where TModel : Model, new()
    {
        var transformations = container.Resolve<ModelTransformationTypedBindings<TModel>>();
        var models = transformations.GetModels(table);
        return models;
    }

    public List<TModel> GetList<TModel>() where TModel : Model, new()
    {
        var transformations = container.Resolve<ModelTransformationTypedBindings<TModel>>();
        var models = transformations.GetModelList(table);
        return models;
    }

    public TModel[] GetArray<TModel>() where TModel : Model, new()
    {
        var transformations = container.Resolve<ModelTransformationTypedBindings<TModel>>();
        var models = transformations.GetModelArray(table);
        return models;
    }
}
