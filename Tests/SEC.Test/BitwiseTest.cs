using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SEC.Test
{
    class BitwiseTest
    {
        ISECParser parser = null;
        [SetUp]
        public void Setup()
        {
            var builder = new SECParserBuilder();
            parser = builder.UseDefaultFilters().Build();
        }

        [Test]
        public void BitwiseAndTest()
        {
            var token = parser.Parse("15 & 8");
            Assert.AreEqual(8, token.Value);
        }

        [Test]
        public void BitwiseXOrTest()
        {
            var token = parser.Parse("15 ^ 8");
            Assert.AreEqual(7, token.Value);
        }

        [Test]
        public void BitwiseOrTest()
        {
            var token = parser.Parse("15 | 8");
            Assert.AreEqual(15, token.Value);
        }

        [Test]
        public void PriorityTest()
        {
            var token = parser.Parse("2 & 8 | 1 ^ 7");
            Assert.AreEqual(6, token.Value);
        }

        [Test]
        public void PriorityWithBrackets()
        {
            var token = parser.Parse("2 & (8 | 1) ^ 7");
            Assert.AreEqual(7, token.Value);
        }
    }
}
