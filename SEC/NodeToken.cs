using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public class NodeToken
    {
        public NodeToken(string token, TokenType type)
        {
            this.Token = token;
            this.Type = type;
        }

        public string Token { get; set; }
        public TokenType Type { get; set; }
    }
}
