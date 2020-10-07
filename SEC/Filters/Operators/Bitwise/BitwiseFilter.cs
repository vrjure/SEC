using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters.Operators.Bitwise
{
    class BitwiseFilter : ITokenFilter
    {
        public int FilterLength => 1;

        public int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '&')
            {
                token = new BitwiseAndToken();
                return 1;
            }
            else if (ch == '^')
            {
                token = new BitwiseXOrToken();
                return 1;
            }
            else if (ch == '|')
            {
                token = new BitwiseOrToken();
                return 1;
            }

            token = null;
            return 0;
        }
    }
}
