using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loaf
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            string[] B_temp = Console.ReadLine().Split(' ');
            int[] B = Array.ConvertAll(B_temp, Int32.Parse);

            //int[] B = { 2,3,4,5,6 };

            Console.WriteLine(loafs(B));
            Console.Read();
        }

        static string loafs (int[] A)
        {
            int c = A.Count(x => (x & 1) == 1);

            if ((c&1) == 1)
                return "NO";

            int prev = 0;
            bool firstFound = false;
            int res = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if ((A[i] & 1) == 1)
                {
                    if(firstFound)
                    {
                        firstFound = false;
                        res += (i - prev) * 2;

                    }
                    else
                    {
                        prev = i;
                        firstFound = true;
                    }
                }
            }
            return res.ToString();
        }

    }
}
