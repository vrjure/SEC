using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEC.Filters
{
    public abstract class OperatorToken : NodeToken
    {
        public OperatorToken(string token, int priority):base(token)
        {
            this.Priority = priority;
        }

        public int Priority { get; }

        public abstract NumberToken Calc(NumberToken left, NumberToken right);

        public override void Parse(TokenStack stack, IEnumerator<INodeToken> reader, ITokenParser parser)
        {
            if (!stack.TryFindLastOperator(out OperatorToken lastOp))
            {
                stack.Push(this);
                return;
            }

            while (lastOp.Priority < this.Priority)
            {
                var array = stack.PopEnd(lastOp).ToArray();
                if (array.Length > 2)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = array.Length - 1 ; i >= 0; i--)
                    {
                        sb.Append(array[i].Token);
                    }
                    throw new InvalidOperationException(sb.ToString());
                }

                var right = array[0] as NumberToken;
                var op = array[1] as OperatorToken;
                var left = stack.Pop() as NumberToken;
                var result = op.Calc(left, right);
                stack.Push(result);

                if (!stack.TryFindLastOperator(out lastOp))
                {
                    stack.Push(this);
                    return;
                }
            }

            stack.Push(this);
        }
    }

    public class OperatorComparer : IComparer<OperatorToken>
    {
        public int Compare(OperatorToken x, OperatorToken y)
        {
            return x.Priority - y.Priority;
        }
    }
}
