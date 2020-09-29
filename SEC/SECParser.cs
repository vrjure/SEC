using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    public class SECParser
    {
        public SECParser()
        {
            
        }

        public object GetResult(string expression)
        {
            Stack<INodeToken> tokenStack = new Stack<INodeToken>();
            TokenReader reader = new TokenReader(expression);
            INodeToken token = null;
            while ((token = reader.Read()) != null)
            {
                if (token is OperatorToken op)
                {
                    OperatorProcess(tokenStack, op);
                }
                else
            }
        }

        private void OperatorProcess(Stack<INodeToken> stack, OperatorToken op)
        {
            Stack<INodeToken> switchToken = new Stack<INodeToken>();

            while (stack.Count > 0)
            {
                var token = stack.Pop();
                if (token is OperatorToken lastOp)
                {
                    if (op.Priority > lastOp.Priority)
                    {
                        var right = switchToken.Pop();
                        if (!(right is NumberToken))
                        {
                            throw new InvalidOperationException($"Invalid token {right}");
                        }

                        var left = stack.Pop();
                        if (!(left is NumberToken))
                        {
                            throw new InvalidOperationException($"Invalid token {left}");
                        }

                        var newToken = lastOp.Calc((NumberToken)left, (NumberToken)right);
                        stack.Push(newToken);
                    }
                    else
                    {
                        while (switchToken.Count > 0)
                        {
                            stack.Push(switchToken.Pop());
                        }
                        stack.Push(op);
                    }
                }
                else
                {
                    switchToken.Push(token);
                }
            }

        }
    }
}
