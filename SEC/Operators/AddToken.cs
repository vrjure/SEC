using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Operators
{
    class AddToken : NodeToken
    {
        public AddToken():base('+', 4, TokenType.Operator)
        {

        }

        public override bool TryRead(TextReader tr, out string token)
        {
            if (tr.Peek() == '+')
            {
                tr.Read();
                token = "+";
                return true;
            }
            token = null;
            return false;
        }
    }
}
