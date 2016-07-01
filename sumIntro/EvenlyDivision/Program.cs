using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenlyDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1012;
            Console.Write(numbersDivisible(n));

            Console.Read();
        }

        static int numbersDivisible(int n)
        {
            int count = 0;
            int num = n;
            int current = 0;
            while(num > 0)
            {
                current = num % 10;
                if (current != 0 && n % current == 0)
                    count++;

                num = num / 10;
            }

            return count;
        }
    }
}
