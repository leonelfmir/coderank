using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexFindEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] A = { "C", "a", "A", "b", "B" };
            //List<string> B = A.ToList();
            //B.Sort(StringComparer.Ordinal);
            //Console.WriteLine(string.Join("",B));
            int tt = int.Parse(Console.ReadLine());
            string[] s = new string[tt];
            for (int i = 0; i < tt; i++)
            {
                s[i] = Console.ReadLine();
                
            }
            Console.WriteLine(sol(string.Join("\n",s)));
            Console.Read();
        }

        static string sol(string s)
        {
            string pattern = @"[A-Za-z0-9._%+-/!#$%&'*=?^_`{|}~]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}";

            HashSet<string> res = new HashSet<string>();

            MatchCollection matches = Regex.Matches(s, pattern);

            foreach (Match m in matches)
            {
                res.Add(m.Value);
            }
            
            List<string> B = res.ToList();
            B.Sort(StringComparer.Ordinal);

            return string.Join(";", B);
        }
    }
}
