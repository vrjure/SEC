using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public abstract class NodeToken : INodeToken
    {
        public NodeToken(string token)
        {
            this.Token = token;
        }

        public string Token { get; }

        public virtual bool Equals(INodeToken other)
        {
            return this.Token == other.Token;
        }
    }
}
