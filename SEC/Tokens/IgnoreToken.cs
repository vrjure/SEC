using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Tokens
{
    class IgnoreToken : TokenFilter
    {
        public IgnoreToken() : base(' ', 0, TokenType.Ignore)
        {

        }

        public override NodeToken Read(TextReader reader)
        {
            while (reader.Peek() == ' ')
            {
                reader.Read();
            }
            return new NodeToken("", this);
        }
    }
}
