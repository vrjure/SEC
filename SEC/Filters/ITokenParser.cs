using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Filters
{
    public interface ITokenParser
    {
        NumberToken Parse(string expression);
        NumberToken Parse(IEnumerator<INodeToken> tokens);
    }
}
