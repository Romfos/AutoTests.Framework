using System;

namespace AutoTests.Framework.PreProcessor.Infrastructure
{
    public class Stream
    {
        private readonly char[] symbols;

        public int Position { get; set; }

        public Stream(string source)
        {
            symbols = source.ToCharArray();
        }

        public bool End => Position >= symbols.Length;

        public char Read()
        {
            Position++;
            return symbols[Position - 1];
        }

        public bool Check(Func<char, bool> conditioin)
        {
            return !End && (conditioin == null || conditioin(symbols[Position]));
        }

        public Reader ReadToken()
        {
            return new Reader(this);
        }
    }
}