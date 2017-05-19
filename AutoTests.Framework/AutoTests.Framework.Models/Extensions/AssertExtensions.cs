using System;
using System.Linq;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Core.Tests;

namespace AutoTests.Framework.Models.Extensions
{
    public static class AssertExtensions
    {
        public static void AreModelEqual<T>(this Assert assert, T expected, T actual, string message)
            where T : Model
        {
            var comparator = assert.Dependencies.GetDependencies<ModelsDependencies>().Comparator;
            var results = comparator.Compare(expected, actual).ToArray();

            if (results.Length > 0)
            {
                var assertMessage = string.Join(Environment.NewLine + " - ", results.Select(x => x.ToString()));
                throw new AssertException($"{message}:\r\n - {assertMessage}");
            }
        }
    }
}