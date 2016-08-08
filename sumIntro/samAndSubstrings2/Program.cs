using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samAndSubstrings2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "04";
            //string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            //string s = lines[0];
            //Console.WriteLine(sol(s));

            //System.IO.File.WriteAllText("Output" + path + ".txt");
            string n = Console.ReadLine();
            Console.WriteLine(sol(n));
            Console.ReadLine();
        }

        static long sol(string n)
        {
            long p = 1000000007;

            long res = 0;

            for (int i = 0; i < n.Length; i++)
            {
                long sum = (n[i] - '0') * (i + 1) * (long)Math.Pow(10, n.Length - i - 1);
                res = (res + sum);
            }

            return res;
        }
    }
}
