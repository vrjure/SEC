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

            if (stack.Count == 0)//like (-1) or -1+1
            {
                if (reader.MoveNext())
                {
                    var next = reader.Current;
                    var token = $"{this}{next}";
                    if (next is NumberToken)
                    {
                        var nNum = new NumberToken($"{token}", double.Parse(token));
                        stack.Push(nNum);
                        return;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Invalid operator {this}");
                    }
                }
            }

            var last = stack.Peek();
            if (last is OperatorToken)
            {
                throw new InvalidOperationException($"Invalid token {this}");
            }

            if (!stack.TryFindLastOperator(out OperatorToken lastOp))
            {
                stack.Push(this);
                return;
            }

            while (lastOp.Priority < this.Priority)
            {
                var right = stack.Pop() as NumberToken;
                var op = stack.Pop() as OperatorToken;
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
