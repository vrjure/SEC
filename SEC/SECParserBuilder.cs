using SEC.Filters;
using SEC.Filters.Operators.Bitwise;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SEC
{
    public class SECParserBuilder
    {
        internal Dictionary<Type, ITokenFilter> Filters = new Dictionary<Type, ITokenFilter>();

        public SECParserBuilder()
        {

        }

        public SECParserBuilder UseDefaultFilters()
        {
            AddFilter<IgnoreFilter>();
            AddFilter<BasicFilter>();
            AddFilter<NumberFilter>();
            AddFilter<BracketsFilter>();
            AddFilter<BitShiftFilter>();
            AddFilter<BitwiseFilter>();
            AddFilter<SingleConditionFilter>();
            AddFilter<DoubleConditionFilter>();
            return this;
        }

        public SECParserBuilder AddFilter(Type filterType, ITokenFilter filter)
        {
            Filters.Add(filterType, filter);
            return this;
        }

        public SECParserBuilder AddFilter<TFilter>() where TFilter : class, ITokenFilter, new()
        {
            return AddFilter(typeof(TFilter), new TFilter());
        }

        public SECParserBuilder AddParameterFilter(Func<string, double> getValueFunc)
        {
            return AddFilter(typeof(ParameterFilter), new ParameterFilter(getValueFunc));
        }

        public SECParserBuilder RemoveFilter<TFilter>() where TFilter : class , ITokenFilter
        {
            this.Filters.Remove(typeof(TFilter));
            return this;
        }

        public SECParserBuilder Clear()
        {
            Filters.Clear();
            return this;
        }

        public ITokenParser Build()
        {
            var sorted = Filters.Values.OrderByDescending(f => f.FilterLength).ToList();
            return new SECParser(sorted);
        }
    }
}
