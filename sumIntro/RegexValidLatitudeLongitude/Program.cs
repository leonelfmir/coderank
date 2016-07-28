using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexValidLatitudeLongitude
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                string s = Console.ReadLine();
                Console.WriteLine("{0}alid", sol(s) ? "V" : "Inv");
            }
        }

        static bool sol(string s)
        {
            string pattern = @"^\([\+-]?(([1-9]?\d|\d\d)(.\d+)?), [\+-]?((1\d|\d)?\d?(.\d+)?)\)$";

            Match match = Regex.Match(s, pattern, RegexOptions.Multiline);

            if (!match.Success)
                return false;

            if (decimal.Parse(match.Groups[1].Value) > 90)
                return false;

            if (decimal.Parse(match.Groups[4].Value) > 180)
                return false;

            return true;
        }
    }
}
