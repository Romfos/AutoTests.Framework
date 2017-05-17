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
            return compiler.Compile(source);
        }

        public T Get<T>()
        {
            return compiler.Compile<T>(source);
        }
    }
}