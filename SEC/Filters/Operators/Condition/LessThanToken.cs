using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class LessThanToken: OperatorToken
    {
        public LessThanToken():base("<", 6)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                if (l.Value < r.Value)
                {
                    return 1;
                }
                return 0;
            });
        }
    }
}
