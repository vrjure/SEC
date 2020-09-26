using SEC.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    public class TokenReader
    {
        private readonly TextReader reader;
        private IEnumerable<TokenFilter> filters;

        public TokenReader(TextReader reader, IEnumerable<TokenFilter> filters)
        {
            this.reader = reader;
            this.filters = filters;
        }

        public TokenReader(string text):this(new StringReader(text), Default.DefaultFilters())
        {
            
        }

        public NodeToken Read()
        {
            var ch = this.reader.Read();
            if (ch == -1)
            {
                return null;
            }

            TokenFilter filter = null;
            foreach (var item in filters)
            {
                if (item.IsMatch((char)ch))
                {
                    filter = item;
                    break;
                }
            }

            if (filter == null)
            {
                throw new InvalidOperationException($"invalid character [{(char)ch}]");
            }

            return filter.Read(reader);
        }
    }
}
