using System.Collections.Generic;

namespace AutoTests.Framework.Models
{
    public class ModelEqualityComparer : IEqualityComparer<Model>
    {
        private readonly ModelComparator modelComparator;

        public ModelEqualityComparer(ModelComparator modelComparator)
        {
            this.modelComparator = modelComparator;
        }

        public bool Equals(Model? x, Model? y)
        {
            if(x == null)
            {
                return y == null;
            }
            if(y == null)
            {
                return false;
            }
            return modelComparator.Compare(x, y);
        }

        public int GetHashCode(Model model)
        {
            return model.GetHashCode();
        }
    }
}
