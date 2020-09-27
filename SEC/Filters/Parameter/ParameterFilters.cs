using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ParameterFilters : ITokenFilter<ParameterToken>
    {
        public bool IsMatch(char ch)
        {
            return ch == '@';
        }

        public ParameterToken Read(TextReader reader)
        {
            StringBuilder sb = new StringBuilder();
            var ch = -1;
            while ((ch = reader.Peek()) > -1)
            {
                if (ch == '@' || ch == '_' || (ch >= 65 && ch <= 90) || (ch >= 97 && ch <= 122) || (ch >= 48 && ch <= 57))
                {
                    sb.Append((char)reader.Read());
                }
                else
                {
                    break;
                }
            }
            return new ParameterToken(sb.ToString());
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
