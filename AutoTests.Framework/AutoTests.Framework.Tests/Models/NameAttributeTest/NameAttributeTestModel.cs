using AutoTests.Framework.Models;
using AutoTests.Framework.Models.Attributes;

namespace AutoTests.Framework.Tests.Models.NameAttributeTest;

    public class NameAttributeTestModel : Model
    {
        [Name("value")]
        public int Data { get; set; }

        public int Value2 { get; set; }
    }
