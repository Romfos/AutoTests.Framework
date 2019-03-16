using System;
using System.Threading.Tasks;

namespace AutoTests.Framework.PreProcessor
{
    public class Evaluator
    {
        public Evaluator(PreProcessorServiceProvider serviceProvider)
        {
        }

        public virtual async Task<T> Evaluate<T>(string code)
        {
            return (T) Convert.ChangeType(code, typeof(T));
        }
    }
}