using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //int t = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll("1 4 5 7 9 10".Split(' '), Int32.Parse);
            int n = A.Length;
            int t = 7;
            int r = n;
            int m = n >> 1;
            int l = 0;
            while(A[m] != t)
            {
                if (t > A[m])
                {
                    l = m;
                    m = (m + r) / 2;
                }
                else
                {
                    r = m;
                    m = (l + m) / 2;
                }
            }

            Console.WriteLine(m);

            Console.Read();
        }
    }
}
