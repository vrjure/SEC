using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class AddFilter : TokenFilter<AddToken>
    {
        public AddFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out AddToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '+')
            {
                token = new AddToken();
                return 1;
            }

            token = null;
            return 0;
        }
    }
}
