using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Tokens
{
    class ExceptToken : TokenFilter
    {
        public ExceptToken():base('/', 3, TokenType.Operator)
        {

        }

        public override NodeToken Read(TextReader reader)
        {
            reader.Read();
            return new NodeToken("/", Type, Priority);
        }
    }
}
