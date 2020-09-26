using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public abstract class OperatorToken : INodeToken
    {
        public OperatorToken(string token, int priority)
        {
            this.Token = token;
            this.Priority = priority;
        }

        public string Token { get; }
        public int Priority { get; }

        public abstract NumberToken Calc(NumberToken left, NumberToken right);

        public override string ToString()
        {
            return Token;
        }
    }
}
