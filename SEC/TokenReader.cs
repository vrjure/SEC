using SEC.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    class TokenReader : IEnumerator<INodeToken>, IEnumerator, IEnumerable<INodeToken>, IEnumerable, IDisposable
    {
        private TextReader reader;
        private IEnumerable<ITokenFilter> filters;
        private readonly string expression;

        public INodeToken Current { get; private set; }

        object IEnumerator.Current => Current;

        protected TokenReader()
        {

        }

        public TokenReader(string expression, IEnumerable<ITokenFilter> filters)
        {
            this.filters = filters;
            this.expression = expression;
            this.reader = new StringReader(this.expression);
        }

        public TokenReader(string expression) : this(expression, Default.DefaultFilters())
        {

        }


        private INodeToken Read()
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

        public bool MoveNext()
        {
            var token = Read();
            if (token == null)
            {
                return false;
            }
            Current = token;
            return true;
        }

        public void Reset()
        {
            this.reader.Dispose();
            this.reader = new StringReader(this.expression);
        }

        public IEnumerator<INodeToken> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
