using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(element(new int[] { 1,2,3}));
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int N = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                Console.WriteLine(element(A));
            }

            Console.ReadLine();
        }

        static string element(int[] A)
        {
            int ln = A.Length;
            if (ln == 0)
                return "NO";

            BigInteger[] sumF = new BigInteger[ln+2];
            BigInteger[] sumB = new BigInteger[ln+2];

            //sumF[0] = A[0];
            //sumB[ln-1] = A[ln-1];

            for (int i = 0; i < ln; i++)
            {
                sumF[i+1] = sumF[i] + A[i];
                sumB[ln-i] = sumB[ln-i+1] + A[ln-i-1];
            }

            for(int i = 1; i < ln+1; i++)
            {
                if (sumF[i - 1] == sumB[i + 1])
                    return "YES";
            }

            return "NO";

        }
    }
}
