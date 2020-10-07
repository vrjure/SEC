using SEC.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Extensions
{
    public static class NumberTokenExtensions
    {
        public static void CheckInteger(this NumberToken token)
        {
            if (IsDecimal(token))
            {
                throw new InvalidOperationException($"{token} cannot be applied operands of value {token.Value}");
            }
        }

        public static bool IsDecimal(this NumberToken token)
        {
            if (token.Value % 1 == 0)
            {
                return false;
            }
            return true;
        }
    }
}
