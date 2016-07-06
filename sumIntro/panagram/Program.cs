using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "We promptly judged antique ivory buckles for the wprize ";

            HashSet <char> alpha = new HashSet<char>();

            foreach(char c in s)
            {
                if (char.IsLetter(c))
                    alpha.Add(char.ToLower(c));
            }

            string res = "not pangram";
            if (alpha.Count == 26)
                res = "pangram";

            Console.WriteLine(res);
            Console.Read();

        }
    }
}
