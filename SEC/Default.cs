using SEC.Operators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public class Default
    {
        private static IgnoreToken ignore = new IgnoreToken();
        private static AddToken addToken = new AddToken();
        public static IEnumerable<TokenFilter> DefaultOperators()
        {
            yield return ignore;
            yield return addToken;
        }
    }
}
