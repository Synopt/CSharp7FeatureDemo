using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
namespace CSharp7FeatureDemo
{
    [TestClass]
    public class ThrowExpressions
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ternary()
        {
            var thing = "pineapple";

            var indexOfFirstT = thing == "tomato" ? thing.IndexOf("t") : throw new ArgumentException();
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullCoalescing()
        {
            string thing = null;

            var notNullThing = thing ?? throw new ArgumentException();
        }
    }
}
