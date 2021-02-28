using NUnit.Framework;

namespace SEC.Test
{
    public class BaseTest
    {
        ISECParser parser = null;
        [SetUp]
        public void Setup()
        {
            var builder = new SECParserBuilder();
            parser = builder.UseDefaultFilters().Build();
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
        public void ModTest()
        {
            var token = parser.Parse("5%2");
            Assert.AreEqual(1, token.Value);
        }

        [Test]
        public void ComplexText()
        {
            var token = parser.Parse("4+2*5 + 6/2-1");
            Assert.AreEqual(16, token.Value);
        }

        [Test]
        public void IgnoreTest()
        {
            var token = parser.Parse(" 4 + 2  * 5 ");
            Assert.AreEqual(14, token.Value);
        }

        [Test]
        public void DecimalTest()
        {
            var token = parser.Parse("3*2.5 +1.2*(1+1)");
            Assert.AreEqual(9.9, token.Value);
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

        [Test]
        public void NegativeNumberTest()
        {
            var token = parser.Parse("5-(-1.2)");
            Assert.AreEqual(6.2, token.Value);
        }
    }
}