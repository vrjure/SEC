using SEC.Filters;
using System;
using System.Collections.Generic;
using System.IO;
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
            AddFilter<NumberFilter>();
            AddFilter<AddFilter>();
            AddFilter<ExceptFilter>();
            AddFilter<LessFilter>();
            AddFilter<MultiplyFilter>();
            AddFilter<BracketsFilter>();
            return this;
        }

        public SECParserBuilder AddFilter<TFilter>() where TFilter : class, ITokenFilter, new()
        {
            Filters.Add(typeof(TFilter), new TFilter());
            return this;
        }

        public SECParserBuilder AddParameterFilter(Func<string, double> getValueFunc)
        {
            Filters.Add(typeof(ParameterFilter), new ParameterFilter(getValueFunc));
            return this;
        }

        public SECParserBuilder RemoveFilter<TFilter>() where TFilter : class , ITokenFilter
        {
            if (this.Filters.ContainsKey(typeof(TFilter)))
            {
                throw new InvalidOperationException($"Type of {typeof(TFilter).Name} is existed");
            }
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
            return new SECParser(Filters.Values);
        }
    }
}
