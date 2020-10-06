using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ParameterFilter : TokenFilter<ParameterToken>
    {
        private readonly Func<string, double> getValueFunc;
        public ParameterFilter(Func<string, double> getValueFunc):base(1)
        {
            this.getValueFunc = getValueFunc;
        }

        public override int Read(ReadOnlyMemory<char> buffer, int offset, out ParameterToken token)
        {
            var index = offset;
            StringBuilder sb = new StringBuilder();
            var ch = buffer.Span[index];
            if (ch != '@')
            {
                token = null;
                return 0;
            }
            while (index < buffer.Length)
            {
                ch = buffer.Span[index];
                if (ch == '@' || ch == '_' || (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || (ch >= 48 && ch <= 57))
                {
                    sb.Append(buffer.Span[index]);
                }
                else
                {
                    break;
                }
                index++;
            }
            var s = sb.ToString();
            token = new ParameterToken(s, this.getValueFunc);
            return s.Length;
        }

    }
}
