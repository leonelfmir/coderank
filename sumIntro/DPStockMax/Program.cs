using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPStockMax
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(sol(n, A));
            }
        }

        static long sol(int n, int[] A)
        {
            int max = 0;
            long stocks = 0;
            for (int i = n-1; i >= 0; i--)
            {
                if (A[i] > max)
                    max = A[i];
                if (A[i] < max)
                    stocks += max - A[i];
            }

            return stocks;
        }
    }
}
