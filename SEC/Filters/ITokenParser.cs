using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public interface ITokenParser
    {   
        Type Token { get; }
        void Parse(Stack<INodeToken> tokenStack, INodeToken token);
    }
}
