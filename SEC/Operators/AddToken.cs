using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Operators
{
    class AddToken : TokenFilter
    {
        public AddToken():base('+', 4, TokenType.Operator)
        {

        }

        public override string Read(TextReader reader)
        {
            return ((char)reader.Read()).ToString();
        }
    }
}
