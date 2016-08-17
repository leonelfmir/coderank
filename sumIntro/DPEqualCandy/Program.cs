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
        }

        static int sol(int n, int[] A)
        {
            Array.Sort(A);

            int diff = 0;
            for(int i = 0; i < n; i++)
            {

            }
        }
    }
}
