using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexHTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "01";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            string res = "";
            int tr = int.Parse(lines[0]);
            for (int i = 1; i < tr; i++)
            {
                string s = lines[i];
                res += extractText(s);
                Console.Write(extractText(s));
            }

            System.IO.File.WriteAllText("Output" + path + ".txt", res);



            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string s = Console.ReadLine();
                Console.Write(extractText(s));
            }

            Console.Read();
        }

        static string extractText(string text)
        {
            string pattern = @"<a href=""(.*?)"".*?>(.*?)</";

            MatchCollection m = Regex.Matches(text, pattern);
            StringBuilder res = new StringBuilder();

            foreach (Match item in m)
            {
                string name = Regex.Replace(item.Groups[2].Value, @"<.*?>", "").Trim(); ;
                res.Append(string.Format("{0},{1}\n", item.Groups[1], name));
            }

            return res.ToString();
        }
    }
}
