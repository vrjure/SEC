using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class IgnoreToken : NodeToken
    {
        public IgnoreToken(string token) : base(token)
        {
            
        }

        public override void Parse(TokenStack stack, IEnumerator<INodeToken> reader, ITokenParser parser)
        {
            
        }
    }
}
