using System;
//
namespace Test_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };
            RoatateArr(ref arr, 2);
            Console.WriteLine(arr.ArrayToString());
            //RecursiveArray(arr, arr.Length);
            Console.ReadKey();
        }

        static void RecursiveArray(int[] arr, int len)
        {
            if (len == 1) return;

            for (int i = 0; i < len; i++)
            {
                Console.WriteLine();
                RecursiveArray(arr, len + 1);
            }
        }

        static void RoatateArr(ref int[] arr, int rotateIndex)
        {
            int[] result = new int[arr.Length];
            result[0] = arr[rotateIndex];
            for (int i = 1,j = 0; i < result.Length; i++,j++)
            {
                
                if (j == rotateIndex)
                {
                    j++;
                }
                result[i] = arr[j];
            }
            arr = result;
        }
    }
}
