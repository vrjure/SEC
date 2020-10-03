using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEC.Filters
{
    class RightBracketsToken : NodeToken
    {
        public RightBracketsToken():base(")")
        {

        }

        public override void Parse(TokenStack stack, IEnumerator<INodeToken> reader, ITokenParser parser)
        {
            
        }
    }
}
