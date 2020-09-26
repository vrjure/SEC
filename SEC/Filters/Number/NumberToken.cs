using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class NumberToken : INodeToken
    {
        public NumberToken(string token)
        {
            this.Token = token;
            this.Value = double.Parse(Token);
        }

        public NumberToken(NumberToken left, NumberToken right, OperatorToken op, Func<NumberToken, NumberToken, double> calc)
        {
            this.Token = $"{left}{op}{right}";
            this.Value = calc(left, right);
        }

        public string Token { get; }

        public double Value { get; }

        public override string ToString()
        {
            return this.Token;
        }
    }
}
