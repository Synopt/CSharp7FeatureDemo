using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class PatternMatching
    {
        [TestMethod]
        public void TypeMatches()
        {
            object o = "1";

            if (o is null) // Constant pattern "null"
            {
                Assert.Fail();
            }

            if (o is int i) // Type pattern "int i"
            {
                Assert.Fail();
            }

            if (o is string s)
            {
                Assert.AreEqual("1", s);
            }
            else
            {
                Assert.Fail();
            }
        }
        
        internal interface IIntConverter
        {
            string Convert(int i);
        }

        internal interface IDoubleConverter
        {
            string Convert(double d);
        }

        internal interface IByteConverter
        {
            string Convert(byte b);
        }

        internal class IntAndByteConverter : IIntConverter, IByteConverter
        {
            public string Convert(int i)
            {
                return i.ToString();
            }

            public string Convert(byte b)
            {
                return b.ToString();
            }
        }

        [TestMethod]
        public void InterfaceMatches()
        {
            var converter = new IntAndByteConverter();

            if (converter is IIntConverter intConverter)
            {
                var result = intConverter.Convert(1);
                Assert.AreEqual("1", result);
            }
            
            if (converter is IDoubleConverter doubleConverter)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TryParseExample()
        {
            object o = "1234";

            if (o is int i || (o is string s && int.TryParse(s, out i)))
            {
                Assert.AreEqual(1234, i);
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [TestMethod]
        public void SwitchExample()
        {
            var converter = new IntAndByteConverter();

            switch (converter)
            {
                case IDoubleConverter doubleConverter:
                    Console.WriteLine($"The converter is an double converter, Here! {doubleConverter.Convert(1234d)}");
                    Assert.Fail();
                    break;
                case IIntConverter intConverter:
                    Console.WriteLine($"The converter is an int converter, Here! {intConverter.Convert(1234)}");
                    break;
                default: // Always evaluated last
                    Console.WriteLine("The converter doesn't implement any converter we know about");
                    Assert.Fail();
                    break;
                case null:
                    throw new ArgumentException(nameof(converter));
            }
        }

        [TestMethod]
        public void PredicateMatch()
        {
            var number = 12;

            switch (number)
            {
                case int i when i == 10:
                    Assert.Fail();
                    break;
                case int i when i > 10:
                    Trace.Write($"i is greater than 10 and is in fact {i}");
                    break;
                case int i when i < 10:
                    Assert.Fail();
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [TestMethod]
        public void PredicateMatchOnAnObject()
        {
            var point = new Point(12, 64);

            switch (point)
            {
                case Point p when p.X == 12 && p.Y == 64:
                    Trace.Write($"This is the one!");
                    break;
                default:
                    Assert.Fail();
                    break;
            }
        }

        [TestMethod]
        public void TwoPatternsInOne()
        {
            var point = new Point(12, 64);

            if (point is Point p && p.Y is int y && y > 30)
            {
                Assert.AreEqual(y, 64);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void VarPatter()
        {
            var point = new Point(12, 64);

            switch (point)
            {
                case var p:
                    Assert.AreEqual(64, p.Y);
                    break;
            }
        }
    }
}