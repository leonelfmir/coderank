using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckBalance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 1, 2, 1, 1, 1, 8, 1, 10, 0, 5, 0 };
            int[,] arr = new int[A.Length, A.Length];
            

            for(int i = 0; i < A.Length; i+=2)
            {
                arr[i, 0] = A[i];
                arr[i, 1] = A[i + 1];
            }

            int n = arr.GetLength(0);
            int k = 3;
            List<int> important = new List<int>();

            int res = 0;

            for (int i = 0; i < n;i++)
            {
                if (arr[i, 1] == 0)
                    res+= arr[i,0];
                else
                    important.Add(arr[i, 0]);
            }

            important.Sort();
            res += important.Skip(important.Count - k).Sum();
            res -= important.Take(important.Count - k).Sum();

            Console.WriteLine(res);
            Console.Read();
        }
    }
}
