using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(String[] args)
        {
            Console.WriteLine(cipher("middle-Outz", 2));

            int n = Convert.ToInt32(Console.ReadLine());
            string s = Console.ReadLine();
            int k = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(cipher(s, k));
        }

        static string cipher(string s, int k)
        {
            var lower = Enumerable.Range('a', 26).Select( c=> (char)c);
            var upper = Enumerable.Range('A', 26).Select(c => (char)c);
            string alphabetU = string.Join("", upper);
            string alphabetL = string.Join("", lower);

            char[] res = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                if(char.IsLetter(s[i]))
                {
                    if (char.IsLower(s[i]))
                        res[i] = alphabetL[(s[i] - 'a' + k) % 26];
                    else
                        res[i] = alphabetU[(s[i] - 'A' + k) % 26];
                }
            }

            return new string(res);
        }
    }
}
