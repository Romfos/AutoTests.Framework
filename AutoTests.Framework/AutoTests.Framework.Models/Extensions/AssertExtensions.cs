using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Core.Steps;

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

        public static void AreContainModel<T>(this Assert assert, IEnumerable<T> expectedList, T actual, string message)
            where T : Model
        {
            var comparator = assert.Dependencies.GetDependencies<ModelsDependencies>().Comparator;

            foreach (var expected in expectedList)
            {
                if (comparator.Compare(expected, actual).Any())
                {
                    return;
                }
            }

            throw new AssertException(message);
        }

        public static void AreNotContainModel<T>(this Assert assert, IEnumerable<T> expectedList, T actual, string message)
            where T : Model
        {
            var comparator = assert.Dependencies.GetDependencies<ModelsDependencies>().Comparator;

            foreach (var expected in expectedList)
            {
                if (comparator.Compare(expected, actual).Any())
                {
                    throw new AssertException(message);
                }
            }
        }
    }
}