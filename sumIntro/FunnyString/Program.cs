using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyString
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            //int T = 1;
            string s = string.Empty;
            for(int i = 0; i < T; i++)
            {
                //s = Console.ReadLine();
                //s = "aaaaa";
                Console.WriteLine("{0}{1}", funnyString(s) ? "" : "Not ", "Funny");

            }

            Console.Read();
        }

        static bool funnyString(string s)
        {
            int ln = s.Length;
            for(int i = 1; i < ln; i++)
            {
                if (Math.Abs(s[i] - s[i - 1]) != Math.Abs(s[ln - i - 1] - s[ln - i]))
                    return false;
            }
            return true;
        }
    }
}
