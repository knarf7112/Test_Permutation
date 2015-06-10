using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//
using Test_Permutation;
using System.Diagnostics;//load extension method

namespace UnitTest_Permutation
{
    [TestClass]
    public class UnitTest_Extension
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void TestMethod_ArrayRotate()
        {
            
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arrRotateLeft = arr.ArrayRotate<int>(true);
            int[] arrRotateRight = arr.ArrayRotate<int>(false);
            Debug.WriteLine("原始Array: " + arr.ArrayToString());             //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            Debug.WriteLine("左旋Array: " + arrRotateLeft.ArrayToString());   //{ 2, 3, 4, 5, 6, 7, 8, 9, 1 }
            Debug.WriteLine("右旋Array: " + arrRotateRight.ArrayToString());  //{ 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        }

        [TestCleanup]
        public void Clear()
        {

        }
    }
}
