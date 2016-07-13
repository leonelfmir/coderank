using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace taum_and_bday
{
    public class Program
    {
        static void Main(String[] args)
        {

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_b = Console.ReadLine().Split(' ');
                long b = Convert.ToInt64(tokens_b[0]);
                long w = Convert.ToInt64(tokens_b[1]);
                string[] tokens_x = Console.ReadLine().Split(' ');
                long x = Convert.ToInt64(tokens_x[0]);
                long y = Convert.ToInt64(tokens_x[1]);
                long z = Convert.ToInt64(tokens_x[2]);

                Console.WriteLine(cost(b, w, x, y, z));

            }
            Console.Read();
        }

        public static BigInteger cost(long b, long w, long x, long y, long z)
        {
            BigInteger res = 0;

            if(y + z < x)
            {
                res = b * (y+z) + w * y;
            }
            else if(z + x < y)
            {
                res = b * x + w * (x + z);
            }
            else
            {
                res = b * x + w *  y;
            }

            return res;
        }
    }
}
