using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    class SECParser : ISECParser
    {
        private readonly ICollection<ITokenFilter> filters;
        private string expression;
        public SECParser(ICollection<ITokenFilter> filters)
        {
            this.filters = filters;
        }

        public NumberToken Parse(string expression)
        {
            this.expression = expression;
            using (TokenReader reader = new TokenReader(expression, filters))
            {
                return Parse(reader);
            }
        }

        public NumberToken Parse(IEnumerator<INodeToken> reader)
        {
            TokenStack stack = new TokenStack(this.expression.Length);

            while (reader.MoveNext())
            {
                reader.Current.Parse(stack, reader, this);
            }

            while (stack.Count > 1)
            {
                var right = stack.Pop() as NumberToken;
                if (right == null)
                {
                    throw new InvalidOperationException($"{right} is not a {nameof(NumberToken)}");
                }
                var op = stack.Pop() as OperatorToken;
                if (op == null)
                {
                    throw new InvalidOperationException($"{op} is not a {nameof(OperatorToken)}");
                }
                var left = stack.Pop() as NumberToken;
                if (left == null)
                {
                    throw new InvalidOperationException($"{left} is not a {nameof(NumberToken)}");
                }

                var newToken = op.Calc(left, right);
                stack.Push(newToken);
            }
            return stack.Pop() as NumberToken;
        }
    }
}
