using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    public class SECParser : ITokenParser
    {
        public SECParser()
        {
            
        }

        public NumberToken Parse(string expression)
        {
            using (TokenReader reader = new TokenReader(expression))
            {
                return Parse(reader);
            }
        }

        public NumberToken Parse(IEnumerable<INodeToken> tokens)
        {
            TokenStack stack = new TokenStack();
            foreach (var item in tokens)
            {
                item.Parse(stack, this);
            }

            while (stack.Count > 1)
            {
                var right = stack.Pop() as NumberToken;
                var op = stack.Pop() as OperatorToken;
                var left = stack.Pop() as NumberToken;

                var newToken = op.Calc(left, right);
                stack.Push(newToken);
            }
            return stack.Pop() as NumberToken;
        }
    }
}
