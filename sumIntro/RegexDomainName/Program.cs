using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexDomainName
{
    class Program
    {
        static void Main(string[] args)
        {
            //readfile
            string path = "01";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            System.IO.File.WriteAllText("Output" + path + ".txt", sol(string.Join("\n", lines)));
            //Console.WriteLine(sol(string.Join("\n", lines)));
            int tt = int.Parse(Console.ReadLine());
            string[] s = new string[tt];
            for (int i = 0; i < tt; i++)
            {
                s[i] = Console.ReadLine();

            }
            Console.WriteLine(sol(string.Join("\n", s)));
            
            Console.Read();
        }

        static string sol(string s)
        {
            string pattern = @"https?://(www|ww2)?\.?([A-Za-z0-9.-]+\.[A-Za-z]{2,4})";

            HashSet<string> res = new HashSet<string>();

            MatchCollection matches = Regex.Matches(s, pattern);

            foreach (Match m in matches)
            {
                res.Add(m.Groups[2].Value);
            }

            List<string> B = res.ToList();
            B.Sort(StringComparer.Ordinal);

            return string.Join("\n", B);
        }
    }
}
