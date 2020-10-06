using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class BracketsFilter : ITokenFilter
    {
        public int FilterLength => 1;

        public int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '(')
            {
                token = new LeftBracketsToken();
                return 1;
            }
            else if (ch == ')')
            {
                token = new RightBracketsToken();
                return 1;
            }

            token = null;
            return 0;
        }
    }
}
