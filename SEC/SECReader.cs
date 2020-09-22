using SEC.Operators;
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
        private readonly TextReader tr;
        private OperateNode Node;
        private readonly Stack<TokenFilter> nodesStack = new Stack<TokenFilter>();
        private Dictionary<char, TokenFilter> tokens = new Dictionary<char, TokenFilter>();
        public SECReader(TextReader tr, IEnumerable<TokenFilter> tokens)
        {
            this.tr = tr;
            this.tokens = tokens.ToDictionary(f=>f.Token);
        }

        public SECReader(string text):this(new StringReader(text), Default.DefaultOperators())
        {
            
        }
        
        private void Read(TextReader reader)
        {
            var ch = -1;
            while ((ch = reader.Peek()) > -1)
            {
                if (!tokens.TryGetValue((char)ch, out TokenFilter nodeToken))
                {
                    throw new InvalidOperationException($"invalid character [{ch}]");
                }

                var token = nodeToken.Read(reader);


            }
        }
    }
}
