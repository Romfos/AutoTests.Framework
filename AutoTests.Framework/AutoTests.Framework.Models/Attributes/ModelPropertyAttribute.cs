using System;

namespace AutoTests.Framework.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ModelPropertyAttribute : Attribute
    {
    }
}