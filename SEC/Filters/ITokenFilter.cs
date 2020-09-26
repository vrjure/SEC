using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public interface ITokenFilter
    {
        bool IsMatch(char ch);

        INodeToken Read(TextReader reader);
    }

    public interface ITokenFilter<TToken> : ITokenFilter where TToken: INodeToken
    {
        new TToken Read(TextReader reader);
    }

}
