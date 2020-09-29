using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public abstract class OperatorToken : NodeToken
    {
        public OperatorToken(string token, int priority):base(token)
        {
            this.Priority = priority;
        }

        public int Priority { get; }

        public abstract NumberToken Calc(NumberToken left, NumberToken right);

        public override string ToString()
        {
            return Token;
        }
    }
}
