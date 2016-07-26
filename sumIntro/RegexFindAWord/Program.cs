using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexFindAWord
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            string[] s = new string[t];
            for (int i = 0; i < t; i++)
            {
                s[i] = Console.ReadLine();

            }

            int tt = int.Parse(Console.ReadLine());

            for (int i = 0; i < tt; i++)
            {
                string ss = Console.ReadLine();
                Console.WriteLine(sol(string.Join("\n", s), ss));
            }
            Console.Read();
        }

        static int sol(string s, string word)
        {
            string pattern = @"(\b|\W)" + word + @"(\b|\W)";
            MatchCollection matches = Regex.Matches(s, pattern);

            return matches.Count;
        }
    }
}
