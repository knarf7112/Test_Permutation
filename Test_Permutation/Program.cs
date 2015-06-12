using System;
//
namespace Test_Permutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3,  };
            QQ(arr, 0);
            //RecursiveArray(arr,arr.Length);
            Console.WriteLine("count: " + count);
            Console.ReadKey();
        }
        static int count = 0;
        static void RecursiveArray(int[] arr, int len)
        {
            if (len == 0)
            {
                
                return;
            }

            for (int i = 0; i < len; i++)
            {
                int[] tmp = (int[])arr.Clone();
                int[] tmp2;
                arr.RotateArray<int>(i, i, out tmp);
                Console.WriteLine("第" + i + "次的陣列: " + tmp.ArrayToString());
                int ele = tmp.ArrayShift<int>(out tmp2);
                Console.WriteLine("ele:" + ele);
                RecursiveArray(tmp, len - 1);
                //Console.WriteLine("第" + i + "次的陣列: " + arr.ArrayToString());
                count++;
            }

        }

        static void QQ(int[] arr,int len)
        {
            if (len == arr.Length) return;
            Console.WriteLine("len=" + len);
            for (int i = 0; i <= len; i++)
            {
                int[] tmp;
                arr.RotateArray<int>(i, len, out tmp);
                Console.WriteLine("i=" + i + ": len=" + len + ": arr=" + tmp.ArrayToString());
                QQ(tmp, len + 1);
            }
        }

    }
}
