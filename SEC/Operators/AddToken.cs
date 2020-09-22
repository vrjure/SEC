﻿using System;
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

        public override NodeToken Read(TextReader reader)
        {
            reader.Read();
            return new NodeToken("+", TokenType.Operator);
        }
    }
}
