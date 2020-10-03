using NUnit.Framework;

namespace SEC.Test
{
    public class BaseTest
    {
        SECParser parser = null;
        [SetUp]
        public void Setup()
        {
            parser = new SECParser();
        }

        [Test]
        public void AddTest()
        {
            var token = parser.Parse("1+2");
            Assert.AreEqual(3, token.Value);
        }

        [Test]
        public void LessTest()
        {
            var token = parser.Parse("1-2");
            Assert.AreEqual(-1, token.Value);
        }

        [Test]
        public void MultiplyTest()
        {
            var token = parser.Parse("2*2");
            Assert.AreEqual(4, token.Value);
        }

        [Test]
        public void ExceptTest()
        {
            var token = parser.Parse("4/2");
            Assert.AreEqual(2, token.Value);
        }

        [Test]
        public void ComplexText()
        {
            var token = parser.Parse("4+2*5");
            Assert.AreEqual(14, token.Value);
        }

        [Test]
        public void IgnoreTest()
        {
            var token = parser.Parse(" 4 + 2  * 5 ");
            Assert.AreEqual(14, token.Value);
        }
    }
}