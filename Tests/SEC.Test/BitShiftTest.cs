using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Test
{
    class BitShiftTest
    {
        ITokenParser parser = null;
        [SetUp]
        public void Setup()
        {
            var builder = new SECParserBuilder();
            parser = builder.UseDefaultFilters().Build();
        }

        [Test]
        public void ShiftLeftTest()
        {
            var token = parser.Parse("1<<3");
            Assert.AreEqual(8, token.Value);
        }

        [Test]
        public void ShiftRightTest()
        {
            var token = parser.Parse("8>> 3");
            Assert.AreEqual(1, token.Value);
        }

        [Test]
        public void PriorityTest()
        {
            var token = parser.Parse("1+2 << 1");
            Assert.AreEqual(6, token.Value);
        }

        [Test]
        public void PriorityWithBracketsTest()
        {
            var token = parser.Parse("1+(2 << 1)");
            Assert.AreEqual(5, token.Value);
        }
    }
}
