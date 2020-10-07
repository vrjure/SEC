using SEC.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters.Operators.Bitwise
{
    class BitwiseXOrToken : OperatorToken
    {
        public BitwiseXOrToken() : base("^", 9)
        {

        }

        public override NumberToken Calc(NumberToken left, NumberToken right)
        {
            return new NumberToken(left, right, this, (l, r) =>
            {
                l.CheckInteger();
                r.CheckInteger();
                return (int)l.Value ^ (int)r.Value;
            });
        }
    }
}
