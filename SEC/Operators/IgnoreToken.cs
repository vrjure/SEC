using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Operators
{
    class IgnoreToken : NodeToken
    {
        public IgnoreToken() : base(' ', 0, TokenType.Ignore)
        {

        }

        public override bool TryRead(TextReader reader, out string token)
        {
            bool isMatch = false;
            while (reader.Peek() == ' ')
            {
                reader.Read();
                isMatch = true;
            }
            if (isMatch)
            {
                token = "";
            }
            else
            {
                token = null;
            }
            return isMatch;
            
        }
    }
}
