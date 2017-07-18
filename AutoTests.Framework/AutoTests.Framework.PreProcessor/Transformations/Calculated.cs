namespace AutoTests.Framework.PreProcessor.Transformations
{
    public class Calculated
    {
        private readonly Compiler compiler;
        private readonly string source;

        public Calculated(Compiler compiler, string source)
        {
            this.compiler = compiler;
            this.source = source;
        }

        public object Get()
        {
            return compiler.Parse(source);
        }

        public T Get<T>()
        {
            return compiler.Parse<T>(source);
        }
    }
}