using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp7FeatureDemo
{
    [TestClass]
    public class RefReturns
    {
        [TestMethod]
        public void Example()
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8};

            ref var place = ref Find(a, 5);
            place = 100;

            Assert.AreEqual(100, a[4]);
        }    
        
        internal ref int Find(int[] numbers, int number)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] == number)
                {
                    return ref numbers[i];
                }
            }

            throw new IndexOutOfRangeException($"{nameof(number)} {number} not found.");
        }

        //[testmethod]
        //public void reflocal()
        //{
        //    int a = 1, b = 2, c = 3;
        //    ref int _max = ref max(ref a, ref b, ref c);
        //    _max = 4;
        //    assert.areequal(1, a); // true
        //    assert.areequal(2, b); // true
        //    assert.areequal(4, c); // true

        //    ref int max(ref int first, ref int second, ref int third)
        //    {
        //        ref int max = ref first;
        //        if (second > first) { max = second; }
        //        if (third > max) { max = third; }
        //        return ref max;
        //    }
        //}
    }
}
