using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    class NumberFilters : ITokenFilter
    {
        HashSet<char> chars = new HashSet<char>();
        public NumberFilters()
        {
            chars.Add('0');
            chars.Add('1');
            chars.Add('2');
            chars.Add('3');
            chars.Add('4');
            chars.Add('5');
            chars.Add('6');
            chars.Add('7');
            chars.Add('8');
            chars.Add('9');
        }

        public bool IsMatch(char ch)
        {
            if (ch == '.')
            {
                throw new InvalidOperationException($"Invalid character .");
            }
            return chars.Contains(ch);
        }

        public INodeToken Read(TextReader reader)
        {
            StringBuilder sb = new StringBuilder();
            var ch = -1;
            while ((ch = reader.Peek()) > -1)
            {
                if (ch >= 48 && ch <= 57 || ch == '.')
                {
                    reader.Read();
                    sb.Append((char)ch);
                }
                else
                {
                    break;
                }
            }
            return new NumberToken(sb.ToString());
        }
    }
}
