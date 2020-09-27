using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class BracketsFilters : ITokenFilter<BracketsToken>
    {
        public BracketsFilters()
        {

        }

        public bool IsMatch(char ch)
        {
            return ch == '(' || ch == ')';
        }

        public BracketsToken Read(TextReader reader)
        {
            reader.Read();
            var ch = -1;
            bool invalid = false;
            StringBuilder sb = new StringBuilder();
            while ((ch = reader.Read()) > -1)
            {
                if (ch == ')' || ch == ')')
                {
                    invalid = true;
                    break;
                }
                sb.Append(ch);
            }

            if (!invalid)
            {
                throw new InvalidOperationException("invalid character (");
            }

            return new BracketsToken(sb.ToString());
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
