using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Framework.Core.Exceptions;

namespace AutoTests.Framework.Core.Steps
{
    public class Assert
    {
        public StepsDependencies Dependencies { get; }

        public Assert(StepsDependencies dependencies)
        {
            Dependencies = dependencies;
        }

        public void Batch(params Action<Assert>[] actions)
        {
            var exceptions = new List<AssertException>();
            foreach (var action in actions)
            {
                try
                {
                    action(this);
                }
                catch (AssertException e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Count == 1)
            {
                throw exceptions.First();
            }

            if (exceptions.Count > 1)
            {
                var message = string.Join(Environment.NewLine, exceptions.Select(x => x.Message));
                throw new AssertException(message);
            }
        }

        public void AreEqual<T>(T expected, T actual, string message)
        {
            if (!Equals(expected, actual))
            {
                throw new AssertException(message);
            }
        }

        public void AreNotEqual<T>(T expected, T actual, string message)
        {
            if (Equals(expected, actual))
            {
                throw new AssertException(message);
            }
        }

        public void IsNull<T>(T actual, string message)
            where T : class
        {
            if (actual != null)
            {
                throw new AssertException(message);
            }
        }

        public void IsNotNull<T>(T actual, string message)
            where T : class
        {
            if (actual == null)
            {
                throw new AssertException(message);
            }
        }

        public void IsTrue(bool actual, string message)
        {
            if (!actual)
            {
                throw new AssertException(message);
            }
        }

        public void IsFalse(bool actual, string message)
        {
            if (actual)
            {
                throw new AssertException(message);
            }
        }

        public void Throws<TException>(string message, Action action)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                return;
            }
            throw new AssertException(message);
        }
    }
}