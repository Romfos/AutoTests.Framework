using AutoTests.Framework.PreProcessor.Specflow.Primitives;
using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts
{
    public interface IMatchWith
    {
        Task<bool> MatchWith(ExpressionTable expectedValues);
    }
}
