using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class ShiftRightFilter : TokenFilter<ShiftRightToken>
    {
        public ShiftRightFilter() : base(2)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out ShiftRightToken token)
        {
            if (buffer.Length - offset < 2)
            {
                token = null;
                return 0;
            }

            var span = buffer.Span.Slice(offset, 2);
            if (span[0] == '>' && span[1] == '>')
            {
                token = new ShiftRightToken();
                return 2;
            }
            token = null;
            return 0;
        }
    }
}
