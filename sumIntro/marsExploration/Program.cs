using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marsExploration
{
    class Program
    {
        static void Main(string[] args)
        {
            string S = Console.ReadLine();
            Console.WriteLine(lettersAltered(S));
        }

        static int lettersAltered(string s)
        {
            string original = "SOS";

            int counter = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != original[i % 3])
                    counter++;
            }

            return counter;
        }
    }
}
