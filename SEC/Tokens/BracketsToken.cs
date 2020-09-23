using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Tokens
{
    class BracketsToken : TokenFilter
    {
        public BracketsToken():base('(', 2, TokenType.Group)
        {

        }

        public override NodeToken Read(TextReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
