using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class MultiplyFilter : TokenFilter<MultiplyToken>
    {
        public MultiplyFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out MultiplyToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '*')
            {
                token = new MultiplyToken();
                return 1;
            }

            token = null;
            return 0;
        }
    }
}
