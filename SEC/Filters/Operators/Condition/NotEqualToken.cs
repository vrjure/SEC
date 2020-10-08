﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class NotEqualToken : OperatorToken
    {
        public NotEqualToken():base("!=", 7)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                if (l.Value != r.Value)
                {
                    return 1;
                }
                return 0;
            });
        }
    }
}
