using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ModFilter : TokenFilter<ModToken>
    {
        public ModFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out ModToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '%')
            {
                token = new ModToken();
                return 1;
            }

            token = null;
            return 0;
        }

    }
}
