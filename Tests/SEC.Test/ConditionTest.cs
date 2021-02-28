using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace SEC.Test
{
    public class ConditionTest
    {
        ISECParser parser = null;
        [SetUp]
        public void SetUp()
        {
            var builder = new SECParserBuilder().UseDefaultFilters();
            parser = builder.Build();
        }

        [Test]
        public void GreaterTest()
        {
            var token = parser.Parse("5 > 1");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("3 > 5");
            Assert.AreEqual(0, token.Value);
        }

        [Test]
        public void LessThanTest()
        {
            var token = parser.Parse(" 5 < 1");
            Assert.AreEqual(0, token.Value);

            token = parser.Parse("1< 5");
            Assert.AreEqual(1, token.Value);
        }

        [Test]
        public void GreaterOrEqualTest()
        {
            var token = parser.Parse("3 >= 1");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("3 >= 3");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("1>= 3");
            Assert.AreEqual(0, token.Value);
        }

        [Test]
        public void LessThanOrEqualTest()
        {
            var token = parser.Parse("1 <= 2");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("1 <= 1");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("2 <= 1");
            Assert.AreEqual(0, token.Value);
        }

        [Test]
        public void EqualTest()
        {
            var token = parser.Parse("1 ==1");
            Assert.AreEqual(1, token.Value);

            token = parser.Parse("1== 2");
            Assert.AreEqual(0, token.Value);
        }

        [Test]
        public void NotEqualTest()
        {
            var token = parser.Parse("1 != 1");
            Assert.AreEqual(0, token.Value);

            token = parser.Parse("1 != 2");

            Assert.AreEqual(1, token.Value);
        }

        [Test]
        public void AndOrTest()
        {
            var token = parser.Parse("1 == 1 && 1== 2");
            Assert.AreEqual(0, token.Value);

            token = parser.Parse("1 == 1 || 1 == 2");

            Assert.AreEqual(1, token.Value);
        }
    }
}
