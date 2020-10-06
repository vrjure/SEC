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
    class TokenReader : IEnumerator<INodeToken>, IEnumerator, IDisposable
    {
        private IEnumerable<ITokenFilter> filters;
        private readonly string expression;
        private int offset = 0;
        private int length = 0;

        public INodeToken Current { get; private set; }

        object IEnumerator.Current => Current;

        private Memory<char> buffer;

        protected TokenReader()
        {

        }

        public TokenReader(string expression, IEnumerable<ITokenFilter> filters)
        {
            this.filters = filters;
            this.expression = expression;
            this.offset = 0;
            this.length = this.expression.Length;
            buffer = this.expression.ToCharArray();
        }

        private INodeToken Read()
        {
            if (offset >= this.length)
            {
                return null;
            }
            
            foreach (var item in filters)
            {
                var count = item.Read(buffer, offset, out INodeToken token);
                if (count > 0)
                {
                    offset += count;
                    return token;
                }
            }

            throw new InvalidOperationException($"invalid expression [{this.expression}]");
        }

        public void Dispose()
        {
            buffer = null;
            this.length = 0;
            this.offset = 0;
        }

        public bool MoveNext()
        {
            var token = Read();
            if (token == null)
            {
                Current = null;
                return false;
            }
            Current = token;
            return true;
        }

        public void Reset()
        {
            this.offset = 0;
        }
    }
}
