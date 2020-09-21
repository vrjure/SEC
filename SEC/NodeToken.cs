using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    public abstract class NodeToken
    {
        public NodeToken(char ch, int priority, TokenType type)
        {
            this.Ch = ch;
            this.Priority = priority;
            this.Type = type;
        }

        public char Ch { get; }

        public int Priority { get; }

        public TokenType Type { get; }

        public abstract bool TryRead(TextReader tr, out string token);
    }
}
