using SEC.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    class Default
    {
        private static IgnoreToken ignore = new IgnoreToken();
        private static AddToken addToken = new AddToken();
        public static IEnumerable<NodeToken> DefaultOperators()
        {
            yield return ignore;
            yield return addToken;
        }
    }
}
