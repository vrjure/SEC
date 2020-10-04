using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class MultiplyToken : OperatorToken
    {
        public MultiplyToken() : base("*", 3)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                return l.Value * r.Value;
            });
        }
    }
}
