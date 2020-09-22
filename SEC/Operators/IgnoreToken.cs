using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Operators
{
    class IgnoreToken : TokenFilter
    {
        public IgnoreToken() : base(' ', 0, TokenType.Ignore)
        {

        }

        public override string Read(TextReader reader)
        {
            while (reader.Peek() == ' ')
            {
                reader.Read();
            }
            return "";
        }
    }
}
