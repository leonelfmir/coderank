using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexAlienUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            int tt = int.Parse(Console.ReadLine());

            for (int i = 0; i < tt; i++)
            {
                string ss = Console.ReadLine();
                Console.WriteLine(sol(ss)? "VALID": "INVALID");
            }
            Console.Read();
        }

        static bool sol(string s)
        {
            string pattern = @"^(_|.)\d+[a-zA-Z]*_?$";
            Match match = Regex.Match(s, pattern);

            return match.Success;
        }
    }
}
