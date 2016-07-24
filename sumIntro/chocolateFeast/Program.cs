using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chocolateFeast
{
    class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int c = Convert.ToInt32(tokens_n[1]);
                int m = Convert.ToInt32(tokens_n[2]);

                Console.WriteLine(chocolate(n, c, m));
                
            }
            //Console.ReadLine();
        }

        static int chocolate(int n, int c, int m)
        {
            int wrappers = 0;
            int count = wrappers = n / c;
            int candy = 0;
            while(wrappers >= m)
            {
                candy = wrappers / m;
                count += candy;
                wrappers = candy + (wrappers % m);
            }

            return count;
        }
    }
}
