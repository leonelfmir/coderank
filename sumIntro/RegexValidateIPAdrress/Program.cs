using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexValidateIPAdrress
{
    class Program
    {
        static void Main(string[] args)
        {
            int tt = int.Parse(Console.ReadLine());

            for (int i = 0; i < tt; i++)
            {
                string ss = Console.ReadLine();
                Console.WriteLine(sol(ss.Trim()));
            }
            Console.Read();
        }

        static string sol(string s)
        {
            string p4 = @"^([0-2]?\d?\d?\.){3}[0-2]?\d?\d?$";
            string p6 = @"^(((\d|[a-f])?){4}:){7}((\d|[a-f])?){4}$";

            Match match = Regex.Match(s, p4);
            if (match.Success)
                return "IPv4";

            match = Regex.Match(s, p6);
            if (match.Success)
                return "IPv6";

            return "Neither";
        }
    }
}
