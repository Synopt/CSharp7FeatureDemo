using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class LocalFunctions
    {
        [TestMethod]
        public void BasicExample()
        {
            var result = AddTwoNumbers(2, 3);

            Assert.AreEqual(5, result);

            int AddTwoNumbers(int a, int b)
            {
                return a + b;
            }
        }

        [TestMethod]
        public void ChangingLocalScope()
        {
            var theBase = 3;

            void DropTheBase(int byHowMuch)
            {
                theBase -= byHowMuch;
            }

            DropTheBase(2);

            Assert.AreEqual(1, theBase);
        }

        [TestMethod]
        public void MethodsAllTheWayDown()
        {
            var start = 10;

            var result = DecrementInteger(6);

            int DecrementInteger(int byHowMuch)
            {
                return RecursiveDecrement(start, byHowMuch);

                int RecursiveDecrement(int current, int amountRemaining) =>
                    amountRemaining == 0 ? current : RecursiveDecrement(current - 1, amountRemaining - 1);
            }

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void IteratorWithoutLocalFunction()
        {
            var names = GetNames(string.Empty);

            IEnumerable<string> GetNames(string id)
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var _names = new List<string> { "John", "Pete", "Dave" };
                foreach (var name in _names)
                {
                    yield return name;
                }
            }
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void IteratorWithLocalFunction()
        {
            var names = GetNames(string.Empty);

            IEnumerable<string> GetNames(string id)
            {
                if (string.IsNullOrEmpty(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }

                IEnumerable<string> Enumerate()
                {
                    var _names = new List<string> { "John", "Pete", "Dave" };
                    foreach (var name in _names)
                    {
                        yield return name;
                    }
                }

                return Enumerate();
            }
        }
    }
}
