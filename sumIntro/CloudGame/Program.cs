using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudGame
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int k = Convert.ToInt32(tokens_n[1]);
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp, Int32.Parse);

            Console.WriteLine(Energy(c, n, k));

            Console.ReadLine();
        }

        static int Energy(int[] A, int n, int k)
        {
            int E = 100;
            int i = 0;

            do
            {
                E--;
                i = (i + k) % n;
                if (A[i] == 1)
                    E -= 2;
            }
            while (i != 0);

            return E;
        }
    }
}
