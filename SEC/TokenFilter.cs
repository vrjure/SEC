using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    public abstract class TokenFilter
    {
        public TokenFilter(char token, int priority, TokenType type)
        {
            this.Token = token;
            this.Priority = priority;
            this.Type = type;
        }

        public char Token { get; }

        public int Priority { get; }

        public TokenType Type { get; }

        public abstract NodeToken Read(TextReader reader);
        public abstract NodeToken Calculate(NodeToken left, NodeToken right);
    }
}
