﻿
using System;
namespace Test_Permutation
{
    public static class Extensions
    {
        /// <summary>
        /// 將數字陣列合併成一個字串輸出
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ArrayToString(this int[] arr)
        {
            string tmp = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                tmp += arr[i] + " ";
            }
            return tmp.TrimEnd();
        }

        /// <summary>
        /// 將指定元素抽出到第一個元素,其他元素依原來順序排在後面
        /// ex:{1,2,3,4} == rotate index 2 ==> {3,1,2,4}; {1,2,3,4} == rotate index 1 ==> {2,1,3,4}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="rotateIndex"></param>
        /// <param name="rotatedArr"></param>
        public static void RotateArray<T>(this T[] arr, int rotateIndex, out T[] rotatedArr)
        {
            rotatedArr = new T[arr.Length];
            rotatedArr[0] = arr[rotateIndex];//要被旋轉的陣列元素
            for (int i = 1, j = 0; i < rotatedArr.Length; i++, j++)
            {
                if (j == rotateIndex)
                {
                    j++;
                }
                rotatedArr[i] = arr[j];
            }
        }

        /// <summary>
        /// 固定前len數量的陣列元素並更換第i個陣列元素 ex:{1,2,3,4,5,6} == 固定1,2換5 ==> {1,2,5,3,4,6}
        /// </summary>
        /// <typeparam name="T">陣列元素型別</typeparam>
        /// <param name="arr">原始陣列</param>
        /// <param name="rotateIndex">要置換的陣列索引</param>
        /// <param name="fixedCount">固定的陣列數量(從0開始);固定1就不可換第0個陣列元素</param>
        /// <param name="rotatedArr">旋轉後的新陣列</param>
        public static void RotateArray<T>(this T[] arr, int fixedCount, int rotateIndex, out T[] newArr)
        {
            newArr = new T[arr.Length];
            //--------------------------------------------
            // copy array for rotate 先複製固定的陣列元素
            T[] rotateArr = new T[arr.Length - fixedCount];//存放去掉固定陣列元素的剩餘陣列元素 ex: {1,2,3,4,5} => 固定1,2 => {3,4,5}
            T[] rotatedArr ;
            for (int i = 0; i < rotateArr.Length; i++)
            {
                rotateArr[i] = arr[fixedCount + i];
            }
            rotateArr.RotateArray<T>(rotateIndex - fixedCount, out rotatedArr);//ex: {3,4,5} => 旋轉4 => {4,3,5}
            //--------------------------------------------
            //
            for (int i = 0; i < newArr.Length; i++)
            {
                if (i < fixedCount)
                {
                    newArr[i] = arr[i]; //若i小於固定的元素數量,把固定的陣列元素複製過去 ex:(舊的陣列){1,2,3,4,5} => 固定的部分{1,2} => (新的陣列){1,2, , , ,}
                }
                else
                {
                    newArr[i] = rotatedArr[i - fixedCount];//新陣列複製旋轉後的陣列元素 ex:(舊的陣列){1,2,3,4,5} => 旋轉完成的部分{4,3,5} => (新的陣列){ , ,4,3,5,}
                }
            }
            
        }

        /// <summary>
        /// get array first index data and remove it
        /// 像JavaScript的Shift方法 ex:{1,2,3} ==> shift() ==> {2,3}
        /// 無法改變原本的陣列參考,故out一個Shift過的陣列出來
        /// </summary>
        /// <typeparam name="T">element Type</typeparam>
        /// <param name="arr">origin Array</param>
        /// <returns>arr[0]</returns>
        public static T ArrayShift<T>(this T[] arr, out T[] newArr)
        {
            newArr = new T[arr.Length - 1];//準備一個新陣列用來裝載shift後的陣列
            for (int i = 0; i < newArr.Length; i++)
            {
                newArr[i] = arr[i + 1];//陣列元素往前移一位
            }
            //T result = arr[0];//回傳第一個原始陣列元素

            return arr[0];
        }

        /// <summary>
        /// insert data in array head
        /// 像JavaScript的unshift方法 ex:{2,3} ==> unshift(1) ==> {1,2,3}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int ArrayUnShift<T>(this T[] arr, out T[] result, params T[] data)
        {
            result = new T[arr.Length + data.Length];//準備一個新陣列用來裝載unshift後的陣列
            for(int i = 0; i < result.Length; i++)
            {
                if (i < data.Length)
                {
                    result[i] = data[i];
                }
                else
                {
                    result[i] = arr[i - data.Length];
                }
            }
            return arr.Length;
        }

        /// <summary>
        /// {1,2,3} ==> ArrayRotate(false) ==> {2,3,1}
        /// {1,2,3} ==> ArrayRotate( true) ==> {3,1,2}
        /// </summary>
        /// <typeparam name="T">poco type</typeparam>
        /// <param name="arr">origin collection</param>
        /// <returns>rotated collection</returns>
        public static T[] ArrayRotate<T>(this T[] arr,bool rotateLeft = true)
        {

            T[] result = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if(rotateLeft)
                {
                    result[((i - 1) >= 0 ? (i - 1) : (arr.Length - 1))] = arr[i];
                }
                else
                {
                    result[(i + 1) % arr.Length] = arr[i];
                }
                
            }
            return result;
        }
    }
}
