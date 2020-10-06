using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public abstract class TokenFilter<TToken> : ITokenFilter where TToken : INodeToken
    {
        public int FilterLength { get; }

        public TokenFilter(int filterLength)
        {
            this.FilterLength = filterLength;
        }

        int ITokenFilter.Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var count = Read(buffer, offset, out TToken tn);
            token = tn;
            return count;
        }

        public abstract int Read(ReadOnlyMemory<char> buffer, int offset, out TToken token);
    }
}
