using SEC.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    class TokenReader : IDisposable
    {
        private readonly TextReader reader;
        private IEnumerable<ITokenFilter> filters;
        protected TokenReader() : base()
        {

        }

        public TokenReader(TextReader reader, IEnumerable<ITokenFilter> filters)
        {
            this.reader = reader;
            this.filters = filters;
        }

        public TokenReader(string text):this(new StringReader(text), Default.DefaultFilters())
        {
            
        }

        public INodeToken Read()
        {
            var ch = this.reader.Peek();
            if (ch == -1)
            {
                return null;
            }

            ITokenFilter filter = null;
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

        public void Dispose()
        {
            this.reader.Dispose();
        }
    }
}
