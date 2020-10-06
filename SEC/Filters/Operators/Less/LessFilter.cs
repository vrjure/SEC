﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class LessFilter : TokenFilter<LessToken>
    {
        public LessFilter() : base(1)
        {

        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out LessToken token)
        {
            var ch = buffer.Span[offset];
            if (ch == '-')
            {
                token = new LessToken();
                return 1;
            }

            token = null;
            return 0;
        }
    }
}
