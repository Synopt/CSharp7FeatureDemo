using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class OutVariables
    {
        [TestMethod]
        public void TryParse()
        {            
            int.TryParse("134", out var output);

            Assert.AreEqual(134, output);
        }

        private void Two(out int x)
        {
            x = 2;
        }

        private void Two(out string y)
        {
            y = "two";
        }

        [TestMethod]
        public void Ambiguous()
        {
            Two(out int theNumberTwo);
            Two(out string theWordTwo);

            Assert.AreEqual(2, theNumberTwo);
            Assert.AreEqual("two", theWordTwo);
        }

        private void ManyOutVariables(out int x, out int y, out int z)
        {
            x = 15;
            y = 25;
            z = 300;
        }

        [TestMethod]
        public void Wildcards()
        {
            ManyOutVariables(out var one, out var y, out _);

            Assert.AreEqual(15, one);
            Assert.AreEqual(25, y);
        }
    }
}
