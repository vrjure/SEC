using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class BooleanToken : NumberToken
    {
        public BooleanToken(NumberToken left,NumberToken right, OperatorToken op, Func<NumberToken, NumberToken, bool> calc):base($"{left}{right}{op}", calc(left, right) ? 1 : 0)
        {
            
        }

        public BooleanToken(BooleanToken left, BooleanToken right, OperatorToken op, Func<BooleanToken, BooleanToken, bool> calc) : base($"{left}{right}{op}", calc(left, right) ? 1 : 0)
        {
            
        }

        public new bool Value
        {
            get
            {
                var val = base.Value;
                if (val == 1)
                {
                    return true;
                }
                else if (val == 0)
                {
                    return false;
                }

                throw new InvalidOperationException($"Invalid value {val}. the value must 1 or 0");
            }
        }
    }
}
