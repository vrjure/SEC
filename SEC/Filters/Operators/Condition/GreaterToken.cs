using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class GreaterToken : OperatorToken
    {
        public GreaterToken():base(">", 6)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new BooleanToken(left, right, this, (l, r) =>
            {
                return l.Value > r.Value;
            });
        }
    }
}
