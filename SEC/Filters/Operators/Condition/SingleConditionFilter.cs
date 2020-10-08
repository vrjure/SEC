using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class SingleConditionFilter : ITokenFilter
    {
        public int FilterLength => 1;

        public int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var index = offset;
            var ch = buffer.Span[index];
            var consume = 1;
            switch (ch)
            {
                case '>':
                    token = new GreaterToken();
                    break;
                case '<':
                    token = new LessThanToken();
                    break;
                default:
                    token = null;
                    consume = 0;
                    break;
            }
            return consume;
        }
    }
}
