using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FibModified
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

            Console.WriteLine(ModFib(input[0], input[1], input[2]));

            Console.ReadLine();
        }

        static BigInteger ModFib(BigInteger a, BigInteger b, int n)
        {
            BigInteger c = 0;
            for(int i = 3; i <= n; i++)
            {
                c = b * b + a;
                a = b;
                b = c;
            }

            return c;

        }
    }
}
