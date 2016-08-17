using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEqualCandy
{
    class Program
    {
        static void Main(string[] args)
        {
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

            int res = 0;
            for(int i = 1; i < n; i++)
            {
                if(A[i-1] < A[i])
                {
                    int df = A[i] - A[i - 1];
                    res += getDiff(df);
                    A[i] -= df;
                }
            }

            return res;
        }

        static int getDiff(int diff)
        {
            int res = 0;
            int ch = 3;
            int[] chs = { 1, 2, 5 };

            int mod = diff;
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
