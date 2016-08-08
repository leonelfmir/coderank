using System;
using System.Collections.Generic;

using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace samAndSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "04";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            string s = lines[0];
            Console.WriteLine(sol(s));

            //System.IO.File.WriteAllText("Output" + path + ".txt");
            string n = Console.ReadLine();
            Console.WriteLine(sol(n));
            Console.ReadLine();

        }

        static long sol(string n)
        {
            long p = 1000000007;

            long[] s = new long[n.Length];
            long[] r = new long[n.Length];

            s[0] = n[0] - '0';
            r[0] = s[0];
            
            for (int i = 1; i < n.Length; i++)
            {
                s[i] = (((n[i] - '0') * (i+1)) % p + s[i-1] * 10 % p) %p;
                r[i] = (r[i - 1] + s[i]) % p;
            }

            return r[n.Length - 1];
        }

        
    }
}
