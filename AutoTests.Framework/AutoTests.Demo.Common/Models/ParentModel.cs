using AutoTests.Framework.Models;
using AutoTests.Framework.Models.PropertyAttributes;

namespace AutoTests.Demo.Common.Models
{
    public class ParentModel : Model
    {
        [Name("Title")]
        public string Name { get; set; }

        [Disabled]
        public bool Enabled { get; set; }

        public SubModel SubModel { get; private set; }
    }
}