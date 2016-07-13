using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alternating_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine(deletions(s));
            }

            Console.ReadLine();
        }

        static int deletions(string s)
        {
            int res = 0;

            char prev = 'C';
            foreach(char c in s)
            {
                if (c == prev)
                    res++;
                else
                    prev = c;
            }

            return res;
        }
    }
}
