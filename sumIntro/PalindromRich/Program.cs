using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromRich
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                string number = Console.ReadLine();

                Console.WriteLine(palindrome(number, k, n));
            }
            Console.Read();
        }

        static string palindrome(string number, int k, int n)
        {
            char[] res = number.ToCharArray();
            HashSet<int> poss = new HashSet<int>();
            
            for (int i = 0; i < n/2; i++)
            {
                if (res[i] != res[n - i - 1])
                {
                    res[i] = res[n - i - 1] = res[i] > res[n - 1 - i] ? res[i] : res[n - 1 - i];
                    poss.Add(i);
                    k--;
                }
            }

            if (k < 0)
                return "-1";


            for (int i = 0; i < n / 2; i++)
            {
                if (k < 2)
                    break;
                if (res[i] != '9')
                {
                    res[i] = res[n - 1 - i] = '9';
                    k -= 2;
                    if (poss.Contains(i))
                    {
                        k++;
                        poss.Remove(i);
                    }
                }
            }

            if (k > 0)
            {
                if (poss.Count > 0)
                {
                    int p = poss.First();
                    res[p] = res[n - 1 - p] = '9';
                }
                else
                {
                    if ((n & 1) == 1)
                        res[n / 2] = '9';
                }


            }

            return new string(res);
        }
    }
}
