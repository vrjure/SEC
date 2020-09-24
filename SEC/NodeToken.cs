using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public class NodeToken
    {
        public NodeToken(string token, TokenType tokenType, int priority)
        {
            this.Token = token;
            this.TokenType = TokenType;
            this.Priority = priority;
        }

        public NodeToken(NodeToken left, NodeToken right, NodeToken op)
        {
            Token = $"{left}{right}{op}";
            this.TokenType = TokenType.Postfix;
            this.Priority = int.MaxValue;
        }

        public string Token { get; }
        public TokenType TokenType { get; }
        public int Priority { get; }
        public override string ToString()
        {
            return this.Token;
        }
    }
}
