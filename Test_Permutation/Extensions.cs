
using System;
namespace Test_Permutation
{
    public static class Extensions
    {
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
        /// get array first index data and remove it
        /// 像JavaScript的Shift方法 ex:{1,2,3} ==> shift() ==> {2,3}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static T[] ArrayShift<T>(this T[] arr)
        {
            T[] tmp = new T[arr.Length - 1];
            for (int i = 1; i < arr.Length; i++)
            {
                tmp[i - 1] = arr[i];
            }

            return tmp;
        }

        /// <summary>
        /// insert data in array head
        /// 像JavaScript的unshift方法 ex:{2,3} ==> unshift(1) ==> {1,2,3}
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static T[] ArrayUnShift<T>(this T[] arr, T data)
        {
            T[] result = new T[arr.Length + 1];
            result[0] = data;
            Buffer.BlockCopy(arr, 0, result, 1, arr.Length);
            return result;
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
