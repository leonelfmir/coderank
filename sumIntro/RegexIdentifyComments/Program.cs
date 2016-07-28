using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexIdentifyComments
{
    class Program
    {
        static void Main(string[] args)
        {
            //readfile
            string path = "04";
            string[] linestest = System.IO.File.ReadAllLines("input" + path + ".txt");

            //System.IO.File.WriteAllText("Output" + path + ".txt", sol(string.Join("\n", lines)));
            Console.WriteLine(sol(string.Join("\n", linestest)));
            List<string> lines = new List<string>();
            string line = "";
            //while((line = Console.ReadLine()) != null || line != "^z")
            while ((line = Console.ReadLine()) != "^z")
            {
                lines.Add(line);
            }

            Console.WriteLine("Done");

            Console.WriteLine(sol(string.Join("\n", lines)));

            Console.Read();
        }

        static string sol(string s)
        {
            string pattern = @"(//.*(?=\n)|/\*(.*\n*)*?.*\*/)";

            MatchCollection matches = Regex.Matches(s, pattern, RegexOptions.Multiline);

            List<string> res = new List<string>();
            //string temp = "";
            foreach (Match m in matches)
            {
                //temp = Regex.Replace(m.Value, @"\n\s{2,}", "\n ");
                var temp = m.Value.Split('\n').Select( x => x.Trim());

                res.Add(string.Join("\n",temp));
            }

            return string.Join("\n", res);
        }
    }
}
