using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharp7FeatureDemo
{
    [TestClass]
    class Deconstruction
    {
        [TestMethod]
        public void Example()
        {
            (var size, var furType, var shape) = LookupProperties("StuffedAnimal03");

            (string size, string furType, string shape) LookupProperties(string itemId)
            {
                var itemSize = "Medium";
                var itemFurType = "Scaly";
                var itemShape = "Komodo dragon";
                return (itemSize, itemFurType, itemShape);
            }

            Assert.AreEqual("Tiny", size);
            Assert.AreEqual("Scaly", furType);
            Assert.AreEqual("Dragon", shape);
        }

        [TestMethod]
        public void VarShorthand()
        {
            var (size, furType, shape) = LookupProperties("StuffedAnimal04");

            (string size, string furType, string shape) LookupProperties(string itemId)
            {
                var itemSize = "Gigantic";
                var itemFurType = "Floofy";
                var itemShape = "Dog";
                return (itemSize, itemFurType, itemShape);
            }

            Assert.AreEqual("Gigantic", size);
            Assert.AreEqual("Floofy", furType);
            Assert.AreEqual("Dog", shape);
        }

        [TestMethod]
        public void ExistingVariables()
        {
            string size;
            string furType;
            string shape;
            size = furType = shape = "unknnown";

            (size, furType, shape) = LookupProperties("StuffedAnimal05");

            // can't mix declaration and assignment e.g.
            //(size, var furType, shape) = LookupProperties("StuffedAnimal03");

            (string size, string furType, string shape) LookupProperties(string itemId)
            {
                var itemSize = "Diminutive";
                var itemFurType = "Shorthaired";
                var itemShape = "Monkey";
                return (itemSize, itemFurType, itemShape);
            }

            Assert.AreEqual("Diminutive", size);
            Assert.AreEqual("Shorthaired", furType);
            Assert.AreEqual("Monkey", shape);
        }

        public class Person
        {
            public string Forename { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }

            public Person(string forename, string surname, int age)
            {
                Forename = forename;
                Surname = surname;
                Age = age;
            }

            public void Deconstruct(out string forename, out string surname)
            {
                forename = Forename;
                surname = Surname;
            }

            public void Deconstruct(out string forename, out string surname, out int age)
            {
                forename = Forename;
                surname = Surname;
                age = Age;
            }
        }

        [TestMethod]
        public void TypeDeconstruction()
        {
            var (forename, surname) = new Person("Jeff", "Test", 50);
            var (forename2, __) = new Person("Jeff", "Test", 50);
        }
        
        [TestMethod]
        public void Wildcards()
        {
            var (_, surname) = new Person("Jeff", "Test", 50);
        }
    }
}
