using System.Collections.Generic;

namespace Test_Permutation
{
    /// <summary>
    /// 排列組合
    /// </summary>
    public class BackTracking
    {
        static int count = 0;
        /// <summary>
        /// 列舉陣列所有的排列組合
        /// {1,2,3}  => {1,2,3}
        ///             {1,3,2}
        ///             {2,1,3}
        ///             {2,3,1}
        ///             {3,1,2}
        ///             {3,2,1}
        /// </summary>
        /// <param name="arr">要排列組合的陣列</param>
        /// <param name="len">目前旋轉的層數維度</param>
        public static void RecursiveArray(int[] arr, int len,ref List<int[]> result)
        {
            //若已為陣列最後一個維度,印出此排列組合
            if (len == arr.Length - 1)
            {
                //Console.WriteLine(arr.ArrayToString());
                result.Add(arr);//把Recursive的最內層方法結果存入result
                return;
            }
            //從0開始跑到最後一個最後一層的次數 
            //ex: {1,2,3,4}         ==第0層==>           1,2,3,4 ---> 再來先列出固定元素頭為(1)的剩下可能 --> (1),2,3,4 ---> 再來固定(1)(2) --> (1),(2),3,4 ---> 再來固定(1)(2)(3) --> (1),(2),(3),4
            // 第一個元素(頭)有1,2,3,4個可能 ,所以有4次                  第2個元素(頭)可能為2,3,4 ,所以有3次    (1),3,2,4                        (1),(2),4,3
            //                                                                                             (1),4,2,3
            //                                           2,1,3,4 ---> 再來先列出固定元素頭為(2)的剩下可能 --> (2),1,3,4
            //                                                        第2個元素(頭)可能為1,3,4 ,所以有3次    (2),3,1,4
            //                                                                                             (2),4,1,3
            //                                           3,1,2,4 ---> 再來先列出固定元素頭為(3)的剩下可能 --> (3),1,2,4
            //                                                        第2個元素(頭)可能為1,2,4 ,所以有3次    (3),2,1,4
            //                                                                                             (3),4,1,2
            //                                           4,1,2,3 ---> 再來先列出固定元素頭為(4)的剩下可能 --> (4),1,2,3
            //                                                        第2個元素(頭)可能為1,2,3 ,所以有3次    (4),2,1,3
            //                                                                                             (4),3,1,2
            //以此類推以下2,3,4開頭的
            for (int i = len; i < arr.Length; i++)
            {
                int[] tmpArr;
                arr.RotateArray<int>(len, i, out tmpArr);//固定前len數量的陣列元素並更換第i個陣列元素 ex:{1,2,3,4,5,6} ==固定1,2換5==> {1,2,5,3,4,6}
                //Console.WriteLine("第" + i + "次的陣列: " + tmpArr.ArrayToString());
                RecursiveArray(tmpArr, len + 1,ref result);
                //Console.WriteLine("第" + i + "次的陣列: " + arr.ArrayToString());
                count++;//算recursive跑的次數
            }

        }
    }
}
