using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    class BasicFilter : ITokenFilter
    {
        public int FilterLength => 1;

        public int Read(ReadOnlyMemory<char> buffer, int offset, out INodeToken token)
        {
            var ch = buffer.Span[offset];
            int len = 1;
            switch (ch)
            {
                case '+':
                    token = new AddToken();
                    break;
                case '-':
                    token = new LessToken();
                    break;
                case '*':
                    token = new MultiplyToken();
                    break;
                case '/':
                    token = new ExceptToken();
                    break;
                case '%':
                    token = new ModToken();
                    break;
                default:
                    token = null;
                    len = 0;
                    break;
            }

            return len;
        }
    }
}
