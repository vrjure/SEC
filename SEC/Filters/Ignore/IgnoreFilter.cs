using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class IgnoreFilter : ITokenFilter<IgnoreToken>
    {
        public bool IsMatch(char ch)
        {
            return ch == ' ' || ch == '\n';
        }

        public IgnoreToken Read(TextReader reader)
        {
            StringBuilder sb = new StringBuilder();
            var ch = reader.Peek();
            while (ch == ' ' || ch == '\n')
            {
                ch = reader.Read();
                sb.Append(ch);
                ch = reader.Peek();
            }
            return new IgnoreToken(sb.ToString());
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
