﻿using SEC.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class AndToken : OperatorToken
    {
        public AndToken() :base("&&", 11)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            left.CheckBooleanToken();
            right.CheckBooleanToken();
            return new BooleanToken(left as BooleanToken, right as BooleanToken, this, (l, r) =>
            {
                return l.Value && r.Value;
            });
        }
    }
}
