using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerBreaker
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                Console.WriteLine((NM[1] > 1 && (NM[0] & 1) == 1) ? 1 : 2);
            }

            Console.Read();
        }

        static int winnwer(int n, int m)
        {
            int res = 1;
            if (isPrime(m))
                res = (n & 1) == 1 ? 1 : 2;
            else
                res = (n & 1) == 1 ? 2 : 1;

            return res;
        }

        static bool isPrime(int n)
        {
            return true;
        }

        static int reduction(int m, Dictionary<int, int> D)
        {
            if (m == 1)
                return 1;

            if (D.ContainsKey(m))
                return D[m];

            return 0;
        }

        static List<int> divisors(int m)
        {
            List<int> res = new List<int>();
            int mod = 0;
            for (int i = 1; i < m; i++)
            {
                mod = m % i;
                if (mod == 0)
                    res.Add(i);
                //if (mod < 2)
                //    break;
            }

            return res;
        }
    }
}
