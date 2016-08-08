using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRedJhonIsBack
{
    class Program
    {
        static int[,] cnk;
        static Dictionary<int, int> ps = new Dictionary<int, int>();

        static void Main(string[] args)
        {
            cnk = nk(41);
            Console.WriteLine(primes(40));
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(sol(n));
            }

            Console.ReadLine();
        }

        static int sol(int n)
        {
            int res = 0;
            int rest = n / 4;
            for(int i = 0; i <= rest; i++)
            {
                n = n - 4;
                res += cnk[(n < 0 ? 0: n) + 1, 1];
                
            }

            return res;
        }

        static int[,] nk(int size)
        {
            int[,] choose = new int[size, size];

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

        static int primes(int n)
        {
            if()
            bool[] p = new bool[n+1];

            for (int i = 2; i <= Math.Sqrt(n); i++)
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

            return p.Count(x => !x) - 2;
        }
    }
}
