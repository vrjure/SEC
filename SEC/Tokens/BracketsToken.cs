using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Tokens
{
    class BracketsToken : TokenFilter
    {
        public BracketsToken():base('(', 2, TokenType.Expression)
        {

        }

        public override NodeToken Read(TextReader reader)
        {
            reader.Read();
            var ch = -1;
            bool invalid = false;
            StringBuilder sb = new StringBuilder();
            while ((ch = reader.Read()) > -1)
            {
                if (ch == ')')
                {
                    invalid = true;
                    break;
                }
                sb.Append(ch);
            }

            if (!invalid)
            {
                throw new InvalidOperationException("invalid character (");
            }

            return new NodeToken(sb.ToString(), Type, Priority);
        }
    }
}
