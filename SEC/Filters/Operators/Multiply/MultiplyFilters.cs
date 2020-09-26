using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class MultiplyFilters : ITokenFilter<MultiplyToken>
    {
        public bool IsMatch(char ch)
        {
            return ch == '*';
        }

        public MultiplyToken Read(TextReader reader)
        {
            reader.Read();
            return new MultiplyToken();
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
