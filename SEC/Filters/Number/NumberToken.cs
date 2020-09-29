using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class NumberToken : NodeToken
    {
        public NumberToken(string token):base(token)
        {
            this.Value = double.Parse(Token);
        }

        public NumberToken(NumberToken left, NumberToken right, OperatorToken op, Func<NumberToken, NumberToken, double> calc):this($"{left}{op}{right}")
        {
            this.Value = calc(left, right);
        }

        public double Value { get; }

        public override string ToString()
        {
            return this.Token;
        }
    }
}
