using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFine
{
    class Program
    {
        static void Main(String[] args)
        {
            string[] tokens_d1 = Console.ReadLine().Split(' ');
            int d1 = Convert.ToInt32(tokens_d1[0]);
            int m1 = Convert.ToInt32(tokens_d1[1]);
            int y1 = Convert.ToInt32(tokens_d1[2]);
            string[] tokens_d2 = Console.ReadLine().Split(' ');
            int d2 = Convert.ToInt32(tokens_d2[0]);
            int m2 = Convert.ToInt32(tokens_d2[1]);
            int y2 = Convert.ToInt32(tokens_d2[2]);

            Console.WriteLine(fine(d1, m1, y1, d2, m2, y2));
            Console.Read();
        }

        static int fine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int fine = 0;
            DateTime returned = new DateTime(y1, m1, d1);
            DateTime expected = new DateTime(y2, m2, d2);

            if (returned <= expected)
                return fine;

            if(returned.Year > expected.Year)
            {
                fine = 10000;
            }
            else
            {
                if(returned.Month == expected.Month)
                {
                    fine = 15 * (returned.Day - expected.Day);
                }
                else
                {
                    fine = 500 * (returned.Month - expected.Month);
                }
            }

            return fine;

        }
    }
}
