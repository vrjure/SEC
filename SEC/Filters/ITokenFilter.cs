using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public interface ITokenFilter
    {
        int FilterLength { get; }
        int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token);
    }

}
