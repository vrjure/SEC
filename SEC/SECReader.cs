using SEC.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    class SECReader
    {
        private readonly TextReader reader;
        private OperateNode Node;
        private readonly Stack<NodeToken> nodeTokenStack = new Stack<NodeToken>();
        private readonly Stack<NodeToken> nodeTokenSwitchStack = new Stack<NodeToken>();
        private readonly Queue<OperateNode> nodes = new Queue<OperateNode>();
        private Dictionary<char, TokenFilter> tokens = new Dictionary<char, TokenFilter>();

        public SECReader(TextReader reader, IEnumerable<TokenFilter> tokens)
        {
            this.reader = reader;
            this.tokens = tokens.ToDictionary(f=>f.Token);
            Read(reader);
        }

        public SECReader(string text):this(new StringReader(text), Default.DefaultOperators())
        {
            
        }
        
        private void Read(TextReader reader)
        {
            var ch = -1;
            while ((ch = reader.Peek()) > -1)
            {
                if (!tokens.TryGetValue((char)ch, out TokenFilter tf))
                {
                    throw new InvalidOperationException($"invalid character [{ch}]");
                }

                var nodeToken = tf.Read(reader);

                if (nodeToken.Filter.Type == TokenType.Ignore)
                {
                    continue;
                }

                if (nodeToken.Filter.Type != TokenType.Operator)
                {
                    nodeTokenStack.Push(nodeToken);
                }


            }
        }

        private void OperatorTokenPush(NodeToken token)
        {
            if (token.Filter.Type != TokenType.Operator)
            {
                return;
            }

            while (nodeTokenStack.Count > 0)
            {
                var operatorToken = nodeTokenStack.Pop();
                nodeTokenSwitchStack.Push(operatorToken);
                if(operatorToken.Filter.Type == TokenType.Operator)
                {
                    if(token.Filter.Priority < operatorToken.Filter.Priority)
                    {
                        var right = nodeTokenSwitchStack.Pop();
                        if (right.Filter.Type == TokenType.Operator)
                        {
                            throw new InvalidOperationException($"invalid token {right.Token}");
                        }
                        var op = operatorToken;
                        var left = nodeTokenStack.Pop();
                        if (left.Filter.Type == TokenType.Operator)
                        {
                            throw new InvalidOperationException($"invalid token {left.Token}");
                        }
                        var newNode = op.Filter.Calculate(left, right);
                        nodeTokenStack.Push(newNode);
                    }
                    else
                    {
                        while (nodeTokenSwitchStack.Count > 0)
                        {
                            nodeTokenStack.Push(nodeTokenSwitchStack.Pop());
                        }
                    }
                }
            }
        }
        
        private NodeToken PopStack(Stack<NodeToken> stack)
        {
            if (stack.Count > 0)
            {
                return stack.Pop();
            }
            return null;
        }        
    }
}
