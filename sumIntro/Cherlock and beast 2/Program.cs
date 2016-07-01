using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cherlock_and_beast_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //for (int i = 1; i < 25; i++)
            //    Console.WriteLine(number(i));

            int n = 5555;

            Console.WriteLine(number(n));

            Console.Read();
        }

        static string number(int n)
        {
            int n5 = n - (n % 3);
            int n3 = n % 3;

            while(n5 >=0)
            {
                if (n5 % 3 == 0 && n3 % 5 == 0)
                    return new string('5', n5) + new string('3', n3);

                n5 -= 3;
                n3 += 3;
            }
            return "-1";
        }
    }
}
