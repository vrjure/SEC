using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class NumberToken : NodeToken
    {
        public NumberToken(string token, double value):base(token)
        {
            this.Value = value;
        }

        public NumberToken(NumberToken left, NumberToken right, OperatorToken op, Func<NumberToken, NumberToken, double> calc):this($"{left}{op}{right}", calc(left, right))
        {
            
        }

        public double Value { get; }

        public override string ToString()
        {
            return this.Token;
        }
    }
}
