using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace LongFactorials
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            BigInteger res = 1;

            for(int i = 2; i <= n;i++)
            {
                res = BigInteger.Multiply(res, i);
            }

            Console.WriteLine(x);

            Console.Read();
        }


    }
}
