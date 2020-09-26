using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ExceptFilters : ITokenFilter<ExceptToken>
    {

        public bool IsMatch(char ch)
        {
            return ch == '/';
        }

        public ExceptToken Read(TextReader reader)
        {
            reader.Read();
            return new ExceptToken();
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
