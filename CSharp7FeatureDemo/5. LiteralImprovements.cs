using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class LiteralImprovements
    {
        [TestMethod]
        public void DigitSeperators()
        {
            var longDigit = 123_456_789;

            Assert.AreEqual(123456789, longDigit);
        }

        [TestMethod]
        public void DigitSeperators_Hex()
        {
            var longHex = 0xAB_CD_EF;

            Assert.AreEqual(0xABCDEF, longHex);
        }

        [TestMethod]
        public void BinaryLiterals()
        {
            var shortBinary = 0b101;
            Assert.AreEqual(5, shortBinary);

            var longBinary = 0b1111_0010_1101_0001_1010;
            Assert.AreEqual(0b11110010110100011010, longBinary);
            Assert.AreEqual(994586, longBinary);
        }

        [Flags]
        public enum FlaggedEnum
        {
            First =   0b0000_0001,
            Second =  0b0000_0010,
            Third =   0b0000_0100,
            Fourth =  0b0000_1000,
            Fifth =   0b0001_0000,
            Sixth =   0b0010_0000,
            Seventh = 0b0100_0000,
            Eighth =  0b1000_0000
        }

        // Can't use digit seperators:
        //at the beginning of the value(_121)
        //at the end of the value(121_ or 121.05_)
        //next to the decimal (10_.0)
        //next to the exponent character(1.1e_1)
        //next to the type specifier(10_f)
        //immediately following the 0x or 0b in binary and hexadecimal literals(might be changed to allow e.g. 0b_1001_1000)
    }
}
