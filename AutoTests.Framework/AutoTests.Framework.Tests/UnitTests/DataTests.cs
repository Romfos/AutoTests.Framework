using AutoTests.Framework.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using AutoTests.Framework.PreProcessor.Roslyn;
using Microsoft.CodeAnalysis.Scripting;
using AutoTests.Framework.Data.Loaders;
using AutoTests.Framework.Core.Extensions;
using System.Reflection;
using AutoTests.Framework.Tests.Data;
using System.Text.RegularExpressions;

namespace AutoTests.Framework.Tests.UnitTests;

[TestClass]
public partial class DataTests : UnitTestsBase
{
    [TestMethod]
    public void DataHubTest()
    {
        var dataHub = new DataHub();

        dataHub.Add(new DataPath("a.b.c".Split('.')), 123);
        dataHub.Add(new DataPath("a.b.d".Split('.')), 456);
        dataHub.Add(new DataPath("e.b.d".Split('.')), 789);
        var data = dataHub.CreateDynamicObject();

        Assert.AreEqual(123, data.a.b.c);
        Assert.AreEqual(456, data.a.b.d);
        Assert.AreEqual(789, data.e.b.d);
    }

    [TestMethod]
    public async Task DataOverPreProcessorTest()
    {
        var dataHub = new DataHub();

        dataHub.Add(new DataPath("a.b.c".Split('.')), 123);
        dataHub.Add(new DataPath("a.b.d".Split('.')), 456);
        dataHub.Add(new DataPath("e.b.d".Split('.')), 789);

        var globals = new DataOverPreProcessorTestGlobals(dataHub);
        var scriptOptions = ScriptOptions.Default.AddReferences("Microsoft.CSharp");
        var preProcessor = new RoslynPreProcessor(globals, scriptOptions);

        Assert.AreEqual(123, await preProcessor.ExecuteAsync<int>("@Data.a.b.c"));
        Assert.AreEqual(456, await preProcessor.ExecuteAsync<int>("@Data.a.b.d"));
        Assert.AreEqual(789, await preProcessor.ExecuteAsync<int>("@Data.e.b.d"));
    }

    [TestMethod]
    public void JsonDataHubLoaderTest()
    {
        var container = CreateEmptyContainer();
        var jsonResourceLoader = container.Resolve<JsonResourceLoader>();
        var dataHub = new DataHub();

        jsonResourceLoader.LoadJsonResource(dataHub,
            Assembly.GetExecutingAssembly(),
            "AutoTests.Framework.Tests.Data.Json.JsonDataHubLoaderTest.json");

        Assert.AreEqual("123", dataHub.Get(new DataPath("Value")));
    }

    [TestMethod]
    public void BulkJsonDataHubLoaderTest()
    {
        var container = CreateEmptyContainer();
        var jsonResourceLoader = container.Resolve<JsonResourceLoader>();
        var dataHub = new DataHub();

        jsonResourceLoader.LoadJsonResources(dataHub,
            Assembly.GetExecutingAssembly(),
            new Regex("AutoTests.Framework.Tests.Data.(.*).json"));

        Assert.AreEqual("456", dataHub.Get(new DataPath("Json", "BulkJsonDataHubLoaderTest", "Value")));
    }

    [TestMethod]
    public void TextDataHubLoaderTest()
    {
        var container = CreateEmptyContainer();
        var textResourceLoader = container.Resolve<TextResourceLoader>();
        var dataHub = new DataHub();

        textResourceLoader.LoadTextResource(dataHub,
            Assembly.GetExecutingAssembly(),
            "AutoTests.Framework.Tests.Data.Text.TextDataHubLoaderTest.txt",
            new DataPath("test"));

        Assert.AreEqual("123", dataHub.Get(new DataPath("test")));
    }

    [TestMethod]
    public void BulkTextDataHubLoaderTest()
    {
        var container = CreateEmptyContainer();
        var textResourceLoader = container.Resolve<TextResourceLoader>();
        var dataHub = new DataHub();

        textResourceLoader.LoadTextResources(dataHub,
            Assembly.GetExecutingAssembly(),
            new Regex("AutoTests.Framework.Tests.Data.(.*).txt"));

        Assert.AreEqual("456", dataHub.Get(new DataPath("Text", "BulkTextDataHubLoaderTest")));
    }
}
