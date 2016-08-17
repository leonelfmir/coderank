using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DPLongestCommonSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(sol("ccpa", "acera"));
            //Console.WriteLine(sol("aa", "baaa"));

            string s1 = Console.ReadLine();
            string s2 = Console.ReadLine();
            Console.WriteLine(sol(s1, s2));
            Console.Read();
        }

        static long sol(string s1, string s2)
        {
            int[,] table;
            LCS(s1, s2, out table);

            HashSet<string> st = backtrack(s1, s2, s1.Length, s2.Length, table);

            HashSet<char>[] s1H = new HashSet<char>[s1.Length + 1];

            for (int i = 0; i < s1H.Length; i++)
            {
                s1H[i] = new HashSet<char>();
            }

            foreach (string lsc in st)
            {
                Dictionary<int, HashSet<char>> D = new Dictionary<int, HashSet<char>>();
                Dictionary<int, int[]> DS1 = new Dictionary<int, int[]>();

                waysFirst(s2, lsc, D);
                waysMiddle(s2, lsc, D);
                waysLast(s2, lsc, D);

                s1Positions(s1, lsc, DS1);

                for (int i = DS1[0][0]; i <= DS1[0][1]; i++)
                {
                    s1H[i].UnionWith(D[0]);
                }

                for (int j = 1; j < lsc.Length; j++)
                {
                    for (int i = DS1[j][0]+1; i <= DS1[j][1]; i++)
                    {
                        s1H[i].UnionWith(D[j]);
                    }
                }

                for (int i = DS1[lsc.Length][0]; i <= DS1[lsc.Length][1]; i++)
                {
                    s1H[i+1].UnionWith(D[lsc.Length]);
                }

            }

            long res = 0;
            foreach (var item in s1H)
            {
                res += item.Count;
            }

            return res;
        }

        static int LCS(string s1, string s2, out int[,] c)
        {
            c = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 1; i <= s1.Length; i++)
                c[i, 0] = 0;
            for (int i = 1; i <= s2.Length; i++)
                c[0, i] = 0;

            for (int i = 1; i <= s1.Length; i++)
                for (int j = 1; j <= s2.Length; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                    {
                        c[i, j] = Math.Max(c[i - 1, j], c[i, j - 1]);

                    }

                }
            
            return c[s1.Length, s2.Length];

        }

        static HashSet<string> backtrack(string s1, string s2, int i, int j, int[,] c)
        {
            if (i == 0 || j == 0)
                return new HashSet<string>() { "" };
            else if (s1[i - 1] == s2[j - 1])
            {
                HashSet<string> temp = new HashSet<string>();
                HashSet<string> holder = backtrack(s1, s2, i - 1, j - 1, c);
                if (holder.Count == 0)
                {
                    temp.Add(s1[i - 1].ToString());
                }
                foreach (string str in holder)

                    temp.Add(str + s1[i - 1]);


                return temp;
            }
            else
            {
                HashSet<string> Result = new HashSet<string>();
                if (c[i - 1, j] >= c[i, j - 1])
                {
                    HashSet<string> holder = backtrack(s1, s2, i - 1, j, c);

                    foreach (string s in holder)
                        Result.Add(s);
                }

                if (c[i, j - 1] >= c[i - 1, j])
                {
                    HashSet<string> holder = backtrack(s1, s2, i, j - 1, c);

                    foreach (string s in holder)
                        Result.Add(s);
                }


                return Result;
            }

        }

        static void waysFirst(string s2, string lsc, Dictionary<int, HashSet<char>> D)
        {
            int lPos = lsc.Length - 1;
            int i = s2.Length - 1;
            for (; lPos >= 0 ; i--)
            {
                if (s2[i] == lsc[lPos])
                    lPos--;
            }

            if(!D.ContainsKey(0))
                D[0] = new HashSet<char>();

            for (int j = 0; j <= i; j++)
            {
                D[0].Add(s2[j]);
            }
        }

        static void waysMiddle(string s2, string lsc, Dictionary<int, HashSet<char>> D)
        {
            for (int pos = 1; pos < lsc.Length; pos++)
            {

                if (!D.ContainsKey(pos))
                    D[pos] = new HashSet<char>();

                int lPos = lsc.Length - 1;
                int i = s2.Length - 1;
                for (; lPos >= pos; i--)
                {
                    if (s2[i] == lsc[lPos])
                        lPos--;
                }
                i++;

                int j = 0;
                int lPosl = 0;
                for (; lPosl < pos; j++)
                {
                    if (lsc[lPosl] == s2[j])
                        lPosl++;
                }

                //j--;

                for (; j < i; j++)
                {
                    D[pos].Add(s2[j]);
                }
            }
        }

        static void waysLast(string s2, string lsc, Dictionary<int, HashSet<char>> D)
        {
            int pos = lsc.Length;

            if (!D.ContainsKey(pos))
                D[pos] = new HashSet<char>();

            int j = 0;
            int lPosl = 0;
            
            for (; lPosl < pos; j++)
            {
                if (lsc[lPosl] == s2[j])
                    lPosl++;
            }

            //j++;

            for (; j < s2.Length; j++)
            {
                D[pos].Add(s2[j]);
            }
        }

        static void s1Positions(string s1, string lsc, Dictionary<int, int[]> D)
        {
            D[0] = new int[] { 0, findPosRight(s1, lsc, lsc.Length) };
            for (int i = 1; i < lsc.Length; i++)
            {
                D[i] = new int[] { findPosLeft(s1, lsc, i), findPosRight(s1, lsc, lsc.Length - i) };
            }
            D[lsc.Length] = new int[] { findPosLeft(s1, lsc, lsc.Length), s1.Length - 1};
        }

        //search from right to left
        static int findPosRight(string s, string lsc, int lenght)
        {
            int lPos = lsc.Length-1;
            int i = s.Length - 1;
            int posFound = 0;
            for (; posFound < lenght; i--)
            {
                if (s[i] == lsc[lPos])
                {
                    lPos--;
                    posFound++;
                }
            }
            i++;

            return i;
        }

        // search from left to right
        static int findPosLeft(string s, string lsc, int lenght)//
        {
            int j = 0;
            int lPosl = 0;
            for (; lPosl < lenght; j++)
            {
                if (lsc[lPosl] == s[j])
                    lPosl++;
            }
            j--;

            return j;
        }
    }
}
