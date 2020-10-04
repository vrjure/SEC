using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SEC.Test
{
    public class ParameterTest
    {
        ITokenParser parser = null;
        private Dictionary<string, double> valueDict = new Dictionary<string, double>();
        [SetUp]
        public void Setup()
        {
            var builder = new SECParserBuilder();
            parser = builder.UseDefaultFilters().AddParameterFilter(token => {
                return valueDict[token];
            }).Build();
        }

        [Test]
        public void CalcTest()
        {
            valueDict.Add("@p1", 2);
            valueDict.Add("@p2", 2);
            var token = parser.Parse("1+@p1-(@p2 * (2 + 1))");
            Assert.AreEqual(-3, token.Value);
        }
    }
}
