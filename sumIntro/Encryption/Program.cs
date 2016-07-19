using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            //encrypt(new string('c', 73));
            Console.WriteLine(encrypt("if man was meant to stay on the ground god would have given us roots".Replace(" ", String.Empty)));
            Console.Read();
        }

        static string encrypt(string s)
        {
            int maxC = (int)Math.Ceiling(Math.Sqrt(s.Length));

            List<StringBuilder> sb = new List<StringBuilder>();

            int mod = 0;
            for (int i = 0; i < s.Length; i++)
            {
                mod = i % maxC;
                if (sb.Count <= mod)
                    sb.Add(new StringBuilder());

                sb[mod].Append(s[i]);
            }

            return string.Join(" ", sb.Select(x => x));
        }
    }
}
