using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ExceptFilter : TokenFilter<ExceptToken>
    {
        public ExceptFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out ExceptToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '/')
            {
                token = new ExceptToken();
                return 1;
            }
            token = null;
            return 0;
        }
    }
}
