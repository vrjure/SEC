using SEC.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class DoubleConditionFilter : ITokenFilter
    {
        public int FilterLength => 2;

        public int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var index = offset;
            if (buffer.Length - index < 2)
            {
                token = null;
                return 0;
            }
            var ch1 = buffer.Span[index];
            var ch2 = buffer.Span[++index];
            if (ch1 == '>' && ch2 == '=')
            {
                token = new GreaterOrEqualToken();
                return FilterLength;
            }
            else if (ch1 == '<' && ch2 == '=')
            {
                token = new LessThanOrEqualToken();
                return FilterLength;
            }
            else if (ch1 == '=' && ch2 == '=')
            {
                token = new EqualToken();
                return FilterLength;
            }
            else if (ch1 == '!' && ch2 == '=')
            {
                token = new NotEqualToken();
                return FilterLength;
            }
            else if (ch1 == '|' && ch2 == '|')
            {
                token = new OrToken();
                return FilterLength;
            }
            else if (ch1 == '&' && ch2 == '&')
            {
                token = new AndToken();
                return FilterLength;
            }

            token = null;
            return 0;
        }
    }
}
