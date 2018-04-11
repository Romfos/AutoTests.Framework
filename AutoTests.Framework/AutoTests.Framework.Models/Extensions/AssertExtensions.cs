using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core;
using AutoTests.Framework.Core.Exceptions;
using AutoTests.Framework.Core.Steps;
using AutoTests.Framework.Models.Comparator;

namespace AutoTests.Framework.Models.Extensions
{
    public static class AssertExtensions
    {
        public static void AreModelEqual<T>(this Assert assert, T expected, T actual, string message)
            where T : Model
        {
            var comparator = GetComparator(assert);
            var results = comparator.Compare(expected, actual).ToArray();

            if (results.Length > 0)
            {
                var assertMessage = string.Join(Environment.NewLine + " - ", results.Select(x => x.ToString()));
                throw new AssertException($"{message}:\r\n - {assertMessage}");
            }
        }

        public static void AreContainModel<T>(this Assert assert, T expected, IEnumerable<T> items, string message)
            where T : Model
        {
            var comparator = GetComparator(assert);

            foreach (var item in items)
            {
                if (!comparator.Compare(item, expected).Any())
                {
                    return;
                }
            }

            throw new AssertException(message);
        }

        public static void AreNotContainModel<T>(this Assert assert, T expected, IEnumerable<T> items, string message)
            where T : Model
        {
            var comparator = GetComparator(assert);

            foreach (var item in items)
            {
                if (comparator.Compare(item, expected).Any())
                {
                    throw new AssertException(message);
                }
            }
        }

        private static ModelComparator GetComparator(Assert assert)
        {
            var dependenciesProvider = assert.Dependencies as IDependenciesProvider;
            return dependenciesProvider.GetDependencies<ModelsDependencies>().Comparator;
        }
    }
}