using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class Tuples
    {
        [TestMethod]
        public void NoNames()
        {
            var result = LookupProperties("StuffedAnimal01");

            (string, string, string) LookupProperties(string itemId)
            {
                var size = "Large";
                var furType = "Fluffy";
                var shape = "Bear";
                return (size, furType, shape); // tuple literal
            }

            Assert.AreEqual("Large", result.Item1);
            Assert.AreEqual("Fluffy", result.Item2);
            Assert.AreEqual("Bear", result.Item3);
        }

        [TestMethod]
        public void WithNames()
        {
            var result = LookupProperties("StuffedAnimal02");

            (string size, string furType, string shape) LookupProperties(string itemId)
            {
                var size = "Small";
                var furType = "Furry";
                var shape = "Raccoon";
                return (size, furType, shape);
            }

            Assert.AreEqual("Small", result.size);
            Assert.AreEqual("Furry", result.furType);
            Assert.AreEqual("Raccoon", result.shape);
        }

        [TestMethod]
        public async Task GenericExample()
        {
            var result = await GetDimensions("boop");

            Task<(int size, int length)> GetDimensions(string id) 
                => Task.FromResult((size: 1, length: 2));
        }
    }
}
