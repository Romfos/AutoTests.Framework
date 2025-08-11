namespace AutoTests.Framework.Routing.Internal.Exceptions;

internal sealed class UnableToLocateComponentException(string path)
    : Exception($"Unable to locate component by path '{path}'")
{
}
