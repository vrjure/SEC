using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class IgnoreFilter : TokenFilter<IgnoreToken>
    {
        public IgnoreFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out IgnoreToken token)
        {
            var index = offset;
            StringBuilder sb = new StringBuilder();         
            while (index < buffer.Length)
            {
                var ch = buffer.Span[index];
                if (ch == ' ' || ch == '\n' || ch == '\r')
                {
                    sb.Append(ch);
                }
                else
                {
                    break;
                }
                index++;
            }
            token = new IgnoreToken(sb.ToString());
            return sb.Length;
        }
    }
}
