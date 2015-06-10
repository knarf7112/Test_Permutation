using System;
//
namespace Test_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.ReadKey();
        }

        static void RecursiveArray(int[] arr, int len)
        {
            if (len == 1) return;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine();
                RecursiveArray(arr, len + 1);
            }
        }

    }
}
