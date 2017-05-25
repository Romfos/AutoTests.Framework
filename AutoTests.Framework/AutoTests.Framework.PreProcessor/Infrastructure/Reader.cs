using System;
using System.Text;

namespace AutoTests.Framework.PreProcessor.Infrastructure
{
    public class Reader
    {
        private readonly int position;
        private readonly Stream stream;
        private readonly StringBuilder stringBuilder;
        private bool active;

        public Reader(Stream stream)
        {
            this.stream = stream;

            position = stream.Position;
            stringBuilder = new StringBuilder();
            active = true;
        }

        private bool Check(Func<char, bool> condition)
        {
            return active && stream.Check(condition);
        }

        private bool IsActive(Func<char, bool> condition)
        {
            if (!Check(condition))
            {
                active = false;
            }
            return active;
        }

        private void Process(bool append)
        {
            if (append)
            {
                stringBuilder.Append(stream.Read());
            }
            else
            {
                stream.Read();
            }
        }

        public Reader Read(Func<char, bool> condition, bool append = true)
        {
            if (IsActive(condition))
            {
                Process(append);
            }
            return this;
        }

        public Reader Read(char symbol, bool append = true)
        {
            return Read(x => x == symbol, append);
        }

        public Reader Read(string value, bool append = true)
        {
            foreach (var symbol in value)
            {
                Read(symbol, append);
            }
            return this;
        }

        public Reader ReadWhile(Func<char, bool> condition, bool append = true)
        {
            while (Check(condition))
            {
                Process(append);
            }
            return this;
        }

        public Reader Check(Func<string, bool> condition)
        {
            if (active)
            {
                active = condition(stringBuilder.ToString());
            }
            return this;
        }

        public Token Result(Func<string, dynamic> getState, Func<string, string> getSource = null)
        {
            if (active)
            {
                var value = stringBuilder.ToString();
                var token = new Token
                {
                    State = getState(value),
                    Source = getSource?.Invoke(value) ?? "&"
                };
                return token;
            }
            stream.Position = position;
            return null;
        }
    }
}