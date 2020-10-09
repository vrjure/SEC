using System;
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
            return new BooleanToken(left, right, this, (l, r) =>
            {
                return l.Value != r.Value;
            });
        }
    }
}
