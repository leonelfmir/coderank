using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRedJhonIsBack
{
    class Program
    {
        static long[,] cnk;
        static Dictionary<long, int> ps = new Dictionary<long, int>();

        static void Main(string[] args)
        {
            cnk = nk(41);
            int s = 4;
            //Console.WriteLine(sol(s));
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("sol: {0}", sol(n));
            }

            Console.ReadLine();
        }

        static long sol(int n)
        {
            long res = 1;
            n -= 4;
            for (int i = 1; n >= 0; i++)
            {
                res += cnk[n + i, i];
                n -= 4;
            }
            //Console.WriteLine("Res: {0}", res);
            return primes(res);
        }

        static long[,] nk(int size)
        {
            long[,] choose = new long[size, size];

            for (int r = 0; r < size; r++)
            {

                choose[r, 0] = choose[r, r] = 1;

                for (int c = 1; c < r; c++)
                {

                    choose[r, c] = (choose[r - 1, c - 1] + choose[r - 1, c]);
                }
            }

            return choose;
        }

        static int primes(long n)
        {
            if (ps.ContainsKey(n))
                return ps[n];

            bool[] p = new bool[n+1];

            for (int i = 2; i*i <= n; i++)
            {
                if (p[i] == true)
                    continue;

                int j = i+i;
                while(j <= n)
                {
                    p[j] = true;
                    j += i;
                }
            }

            return ps[n] = p.Count(x => !x) - 2;
        }
    }
}
