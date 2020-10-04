using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SEC.Filters
{
    public class BracketsFilter : ITokenFilter
    {
        public BracketsFilter()
        {

        }

        public bool IsMatch(char ch)
        {
            return ch == '(' || ch == ')';
        }

        public INodeToken Read(TextReader reader)
        {
            var ch = reader.Read();
            if (ch == '(')
            {
                return new LeftBracketsToken();
            }
            else if (ch == ')')
            {
                return new RightBracketsToken();
            }

            throw new InvalidOperationException($"Invalid character {(char)ch}");
        }

        INodeToken ITokenFilter.Read(TextReader reader)
        {
            return Read(reader);
        }
    }
}
