using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Tokens
{
    class LessToken : TokenFilter
    {
        public LessToken():base('-', 4, TokenType.Operator)
        {

        }

        public override NodeToken Read(TextReader reader)
        {
            reader.Read();
            return new NodeToken("-", Type, Priority);
        }
    }
}
