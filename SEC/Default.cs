using SEC.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC
{
    public static class Default
    {
        private static IgnoreFilters ignore = new IgnoreFilters();
        private static AddFilters addToken = new AddFilters();
        private static MultiplyFilters multiplyToken = new MultiplyFilters();
        private static LessFilters lessToken = new LessFilters();
        private static ExceptFilters exceptToken = new ExceptFilters();
        private static NumberFilters numberToken = new NumberFilters();

        public static IEnumerable<TokenFilter> DefaultFilters()
        {
            yield return numberToken;
            yield return ignore;
            yield return addToken;
            yield return lessToken;
            yield return multiplyToken;
            yield return exceptToken;
        }
    }
}
