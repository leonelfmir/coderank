using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbsolutePermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8;
            int k = 2;
            Console.WriteLine(string.Join(" ", Enumerable.Range(1, n)));
            Console.WriteLine(absPerm(n, k));
            Console.Read();

            //int t = int.Parse(Console.ReadLine());
            //for (int i = 0; i < t; i++)
            //{
            //    string[] tokens_n = Console.ReadLine().Split(' ');
            //    int n = Convert.ToInt32(tokens_n[0]);
            //    int k = Convert.ToInt32(tokens_n[1]);
            //    Console.WriteLine(absPerm(n, k));
            //}
        }

        static string absPerm(int n, int k)
        {
            bool[] b = new bool[n+1];
            b[0] = true;
            int[] res = new int[n];

            for (int i = 1; i < n+1; i++)
            {
                
                if (i-k > 0 && b[i - k] == false)
                {
                    b[i - k] = true;
                    res[i - 1] = i - k;
                }
                else if (i + k <= n && b[i + k] == false)
                {
                    b[i + k] = true;
                    res[i - 1] = i + k;
                }
                else
                    return "-1";
            }

            return string.Join(" ", res);
        }
    }
}
