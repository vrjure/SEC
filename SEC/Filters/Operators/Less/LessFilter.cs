using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class LessFilter : ITokenFilter<LessToken>
    {
        public bool IsMatch(char ch)
        {
            return ch == '-';
        }

        public LessToken Read(TextReader reader)
        {
            reader.Read();
            return new LessToken();
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
