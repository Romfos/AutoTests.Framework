using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Attributes;

namespace AutoTests.Framework.Tests.Models.DisabledAttributeTest;

    public class DisabledAttributeTestModel : Model
    {
        [Disabled]
        public int Value { get; set; }
    }
