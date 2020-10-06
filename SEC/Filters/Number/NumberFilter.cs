using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class NumberFilter : TokenFilter<NumberToken>
    {
        public NumberFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out NumberToken token)
        {
            var index = offset;
            StringBuilder sb = new StringBuilder();
            var ch = buffer.Span[index];
            if (!(ch >= 48 && ch <= 57))
            {
                token = null;
                return 0;
            }
            while (index < buffer.Length)
            {
                ch = buffer.Span[index];
                if ((ch >= 48 && ch <= 57) || ch == '.')
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
            token = new NumberToken(sb.ToString(), double.Parse(s));
            return s.Length;
        }
    }
}
