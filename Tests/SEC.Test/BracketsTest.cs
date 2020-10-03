using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEC.Test
{
    public class BracketsTest
    {
        SECParser parser = null;
        [SetUp]
        public void Setup()
        {
            parser = new SECParser();
        }

        [Test]
        public void OneBracketsTest()
        {
            var token = parser.Parse("5*(2+1)");
            Assert.AreEqual(15, token.Value);
        }

        [Test]
        public void NestedBracketsTest()
        {
            var token = parser.Parse("5+(2*(1+3))");
            Assert.AreEqual(13, token.Value);
        }
    }
}
