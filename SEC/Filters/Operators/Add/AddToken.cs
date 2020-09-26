using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class AddToken : OperatorToken
    {
        public AddToken() : base("+", 4)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                return l.Value + r.Value;
            });
        }
    }
}
