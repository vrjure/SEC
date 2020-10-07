using SEC.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class ShiftLeftToken : OperatorToken
    {
        public ShiftLeftToken() : base("<<", 5)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                l.CheckInteger();
                r.CheckInteger();
                return (int)l.Value << (int)r.Value;
            });
        }
    }
}
