using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexDetectHtml
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
            Console.WriteLine(tags(string.Join("",s)));
            Console.Read();
        }

        static string tags(string s)
        {
            string pattern = @"<\s*/*(\w+).*?>";
            MatchCollection matches = Regex.Matches(s, pattern);

            HashSet<string> res = new HashSet<string>();

            foreach (Match m in matches)
            {
                res.Add(m.Groups[1].Value);
            }

            var x = from y in res
                    orderby y
                    select y;

            var f = res.OrderBy(g => g);

            return string.Join(";", f);
        }
    }
}
