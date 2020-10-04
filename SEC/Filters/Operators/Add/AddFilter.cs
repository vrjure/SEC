using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class AddFilter : ITokenFilter<AddToken>
    {
        public bool IsMatch(char ch)
        {
            return ch == '+';
        }

        public AddToken Read(TextReader reader)
        {
            reader.Read();
            return new AddToken();
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
