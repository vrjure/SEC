using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public class NodeToken
    {
        public NodeToken(string token, TokenFilter filter)
        {
            this.Token = token;
            this.Filter = filter;
        }

        public NodeToken(NodeToken left, NodeToken right, TokenFilter op)
        {
            Token = $"{left}{right}{op.Token}";
        }

        public string Token { get; }
        public TokenFilter Filter { get; }
    }
}
