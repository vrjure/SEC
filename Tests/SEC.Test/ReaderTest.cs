using NUnit.Framework;

namespace SEC.Test
{
    public class ReaderTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTest()
        {
            var expression = "1+2*3";
            var reader = new TokenReader(expression);
            var postFix = reader.ReadToPostfix();
            Assert.AreEqual("123*+", postFix);
            Assert.Pass();
        }
    }
}