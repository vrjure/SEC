﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class ExceptToken : OperatorToken
    {
        public ExceptToken(): base("/", 3)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                return l.Value / r.Value;
            });
        }
    }
}
