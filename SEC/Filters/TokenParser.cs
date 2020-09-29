using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public abstract class TokenParser<T> : ITokenParser where T : INodeToken
    {
        public Type Token => typeof(T);

        public void Parse(Stack<INodeToken> tokenStack, INodeToken token)
        {
            Parse(tokenStack, token);
        }

        protected abstract void Parse(Stack<INodeToken> tokenStack, T token);
    }
}
