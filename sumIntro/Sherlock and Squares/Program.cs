using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sherlock_and_Squares
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for(int i = 0; i < T; i++)
            {
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                Console.WriteLine(squares(A[0], A[1]));
            }

            Console.ReadLine();
        }

        static double squares(int A, int B)
        {
            double asqr = Math.Truncate(Math.Sqrt(A));
            double bsqr = Math.Truncate(Math.Sqrt(B));

            double diff = Math.Truncate(bsqr - asqr);
            if (asqr * asqr == A)
                diff++;

            return diff;
        }
    }
}
