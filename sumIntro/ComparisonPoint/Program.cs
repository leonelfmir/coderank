using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparisonPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] res = comparePoints(A, B);
            Console.WriteLine("{0} {1}", res[0], res[1]);
        }

        static int[] comparePoints(int[] A, int[] B)
        {
            int aCount = 0;
            int bCount = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > B[i])
                    aCount++;
                else if (B[i] > A[i])
                    bCount++;
            }

            return new int[] { aCount, bCount};
        }
    }
}
