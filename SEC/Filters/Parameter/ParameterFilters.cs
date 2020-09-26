using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class ParameterFilters : TokenFilter
    {
        public ParameterFilters():base(0, TokenType.Parameter)
        {

        }

        public override bool IsMatch(char ch)
        {
            return ch == '@';
        }

        public override NodeToken Read(TextReader reader)
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
            return new NodeToken(sb.ToString(), Type, Priority);
        }
    }
}
