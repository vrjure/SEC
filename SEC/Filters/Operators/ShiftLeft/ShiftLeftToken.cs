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
                if (l.Value % 1 != 0)
                {
                    throw new InvalidOperationException($"{this.Token} cannot be applied operands of value {l.Value}");
                }

                if (r.Value % 1 != 0)
                {
                    throw new InvalidOperationException($"{this.Token} cannot be applied operands of value {r.Value}");
                }
                return (int)l.Value << (int)r.Value;
            });
        }
    }
}
