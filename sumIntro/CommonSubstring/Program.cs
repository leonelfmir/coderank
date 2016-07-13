using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                string s1 = Console.ReadLine();
                string s2 = Console.ReadLine();
                Console.WriteLine("{0}", substring(s1, s2) ? "YES" : "NO");
            }
            Console.Read();
        }

        //static bool substring(string s1, string s2)
        //{
        //    string small = s1.Length < s2.Length ? s1 : s2;
        //    string large = small == s1 ? s2 : s1;

        //    foreach (var c in small)
        //    {
        //        if (large.Contains(c))
        //            return true;
        //    }

        //    return false;
        //}

        static bool substring(string s1, string s2)
        {
            bool[] alphabet = new bool[26];

            foreach (var item in s1)
            {
                alphabet[item - 'a'] = true;
            }

            foreach (var item in s2)
            {
                if (alphabet[item - 'a'])
                    return true;
            }

            return false;
        }
    }
}
