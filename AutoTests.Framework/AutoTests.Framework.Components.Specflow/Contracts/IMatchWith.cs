using AutoTests.Framework.Models.Specflow;
using System.Threading.Tasks;

namespace AutoTests.Framework.Components.Specflow.Contracts;

public interface IMatchWith
{
    Task<bool> MatchWithAsync(ModelExpression expression);
}
