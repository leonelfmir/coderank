using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flatlandPowerplants
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine(maxDistance(new int[] { 6, 7 }, 8,2));

            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp, Int32.Parse);
            Console.WriteLine(maxDistance(c, n, m));
        }

        static int maxDistance(int[] C, int n, int m)
        {
            Array.Sort(C);

            int max = 0;

            for (int i = 0; i < m - 1; i++)
            {
                max = Math.Max(max, (C[i + 1] - C[i]) / 2);
            }

            max = Math.Max(max, (C[0] - 0));
            max = Math.Max(max, n - 1 - C[m - 1]);

            return max;
        }
    }
}
