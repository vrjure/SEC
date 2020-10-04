using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public class LeftBracketsToken : NodeToken
    {
        private static RightBracketsToken rightBracketsToken = new RightBracketsToken();
        public LeftBracketsToken() : base("(")
        {

        }

        public override void Parse(TokenStack stack, IEnumerator<INodeToken> reader, ITokenParser parser)
        {
            var lB = 1;
            var rB = 0;
            List<INodeToken> subs = new List<INodeToken>();
            while (reader.MoveNext())
            {
                var current = reader.Current;

                if (current.Equals(this))
                {
                    lB++;
                    subs.Add(current);
                }
                else if (current.Equals(rightBracketsToken))
                {
                    rB++;
                    if (lB == rB)
                    {
                        break;
                    }
                    else
                    {
                        subs.Add(current);
                    }
                }
                else
                {
                    subs.Add(current);
                }
            }

            if (lB != rB)
            {
                throw new InvalidOperationException("Brackets are not closed");
            }

            var result = parser.Parse(subs.GetEnumerator());
            stack.Push(result);
        }
    }
}
