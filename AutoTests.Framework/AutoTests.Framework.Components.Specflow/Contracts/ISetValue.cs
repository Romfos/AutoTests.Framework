using AutoTests.Framework.PreProcessor;
using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts;

    public interface ISetValue
    {
        Task SetValueAsync(IExpression expression);
    }
