using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class NumberFilter : TokenFilter<NumberToken>
    {
        public NumberFilter() : base(1000)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out NumberToken token)
        {
            var index = offset;
            StringBuilder sb = new StringBuilder();
            var ch = buffer.Span[index];
            if (!Char.IsDigit(ch))
            {
                token = null;
                return 0;
            }

            while (index < buffer.Length)
            {
                ch = buffer.Span[index];
                if (Char.IsDigit(ch) || ch == '.')
                {
                    sb.Append(ch);
                }
                else
                {
                    break;
                }
                index++;
            }
            var s = sb.ToString();
            if (s.EndsWith("."))
            {
                throw new InvalidOperationException($"Invalid number {s}");
            }
            token = new NumberToken(sb.ToString(), double.Parse(s));
            return s.Length;
        }
    }
}
