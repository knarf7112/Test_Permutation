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
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr.ArrayShift(out arr);
            //}
            int[] arrRotateLeft = arr.ArrayRotate<int>(true);                 //向左旋轉一位
            int[] arrRotateRight = arr.ArrayRotate<int>(false);               //向右旋轉一位
            Debug.WriteLine("原始Array: " + arr.ArrayToString());             //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            Debug.WriteLine("左旋Array: " + arrRotateLeft.ArrayToString());   //{ 2, 3, 4, 5, 6, 7, 8, 9, 1 }
            Debug.WriteLine("右旋Array: " + arrRotateRight.ArrayToString());  //{ 9, 1, 2, 3, 4, 5, 6, 7, 8 }
        }

        [TestMethod]
        public void TestMethod_ArrayShift()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] newArr;
            int dataIndex1 = arr.ArrayShift<int>(out newArr);//將第一個陣列元素shift出來
            Debug.WriteLine("原始Array: " + arr.ArrayToString());             //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }  
            Debug.WriteLine("位移出來的資料: " + dataIndex1);
            Debug.WriteLine("往前位移後的新Array: " + newArr.ArrayToString());
        }

        [TestMethod]
        public void TestMethod_ArrayUnShift()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] shiftArr;
            int[] unshiftArr;
            DateTime start = DateTime.Now;
            int dataIndex1 = arr.ArrayShift<int>(out shiftArr);//將第一個陣列元素shift出來
            int unshiftArrLength = shiftArr.ArrayUnShift<int>(out unshiftArr, dataIndex1);//new int[] { 0, 1 });//插入原來shift出來的元素
            DateTime end = DateTime.Now;
            Debug.WriteLine("原始Array: " + arr.ArrayToString());             //{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }  
            Debug.WriteLine("Shift後的新Array: " + shiftArr.ArrayToString());
            Debug.WriteLine("位移出來的資料: " + dataIndex1);
            Debug.WriteLine("Unshift後的新Array: " + unshiftArr.ArrayToString());
            Debug.WriteLine("Speend Time: " + (end-start).TotalMilliseconds + " ms");
        }

        [TestMethod]
        public void TestMethod_RotateArray()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int[] rotatedArr;
            for (int i = 0; i < arr.Length; i++)
            {
                arr.RotateArray<int>(i, out rotatedArr);
                Debug.WriteLine("抽換第" + i + "個後的新陣列: " + rotatedArr.ArrayToString());
            }
        }

        [TestMethod]
        public void TestMethod_RotateArrayIncludeFixedCount()
        {
            //int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] arr = new int[] { 1, 2, 3, 4, };
            int[] rotatedArr;
            for (int i = 0; i < arr.Length; i++)
            {
                arr.RotateArray<int>(i, i,out rotatedArr);
                Debug.WriteLine("抽換第" + i + "個後的新陣列: " + rotatedArr.ArrayToString());
            }
        }

        [TestCleanup]
        public void Clear()
        {

        }
    }
}
