using SEC.Operators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC
{
    class SECReader
    {
        private readonly TextReader tr;
        private OperateNode Node;
        private readonly Stack<OperateNode> nodesStack = new Stack<OperateNode>();
        private IEnumerable<NodeToken> tokens;
        public SECReader(TextReader tr, IEnumerable<NodeToken> tokens)
        {
            this.tr = tr;
            this.tokens = tokens;
            Check(tokens);
        }

        public SECReader(string text):this(new StringReader(text), Default.DefaultOperators())
        {
            
        }

        private void Check(IEnumerable<NodeToken> tokens)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            foreach (var item in tokens)
            {
                dict.Add(item.Ch, item.Priority);
            }
        }
        
        private void Read(TextReader reader)
        {
            OperateNode node = null;
            while (reader.Peek() > -1)
            {   
                foreach (var item in this.tokens)
                {
                    if (item.TryRead(reader, out string token))
                    {
                        if (item.Type == TokenType.Ignore)
                        {
                            break;
                        }
                        if (node == null)
                        {
                            node = new OperateNode();
                        }
                        switch (item.Type)
                        {
                            case TokenType.Ignore:
                                
                                break;
                            case TokenType.Parameter:
                                break;
                            case TokenType.Operator:
                                break;
                            case TokenType.Constant:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                }

                throw new InvalidOperationException($"invalid character [{(char)reader.Peek()}]");
            }

        }
    }
}
