using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEqualCandy3
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] B = { 1, 5, 5 };
            string bb = "1 5 5";
            int[] B = Array.ConvertAll(bb.Split(' '), int.Parse);
            Console.WriteLine(sol(B.Length, B));


            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(sol(n, A));
            }

            Console.Read();
        }

        static int sol(int n, int[] A)
        {
            Array.Sort(A);

            //int res0 = 0;
            //int res1 = 0;
            //int res2 = 2;
            //int min0 = A[0];
            //int min1 = A[0] - 1;
            //int min2 = A[0] - 2;

            int[] chs = { 0, 1, 2 };
            int[] res = new int[chs.Length];
            int min = A[0];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < chs.Length; j++)
                {
                    if(A[i] > min - j)
                        res[j] += getDiff(A[i] - min + j);
                }
                //if (A[i] > min0)
                //{
                //    res0 += getDiff(A[i]-min0);
                //}
                //if (A[i] > min1)
                //{
                //    res1 += getDiff(A[i] - min1);
                //}
            }

            return res.Min();
        }

        static int getDiff(int diff)
        {
            int res = 0;
            int ch = 3;
            int[] chs = { 1, 2, 5 };

            int mod = Math.Abs(diff);
            int div = 0;
            for (int i = ch - 1; i >= 0; i--)
            {
                div = mod / chs[i];
                mod = mod % chs[i];
                res += div;
            }

            return res;

        }
    }
}
