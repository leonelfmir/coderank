using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace theGridSearch1
{
    class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_R = Console.ReadLine().Split(' ');
                int R = Convert.ToInt32(tokens_R[0]);
                int C = Convert.ToInt32(tokens_R[1]);
                string[] G = new string[R];
                for (int G_i = 0; G_i < R; G_i++)
                {
                    G[G_i] = Console.ReadLine();
                }
                string[] tokens_r = Console.ReadLine().Split(' ');
                int r = Convert.ToInt32(tokens_r[0]);
                int c = Convert.ToInt32(tokens_r[1]);
                string[] P = new string[r];
                for (int P_i = 0; P_i < r; P_i++)
                {
                    P[P_i] = Console.ReadLine();
                }

                Console.WriteLine(sol(G, R, C, P, r, c) ? "YES" : "NO");
            }
        }

        static bool sol(string[] G, int R, int C, string[] P, int PR, int PC)
        {
            for (int i = 0; i < R; i++)
            {
                if (matchRegex(G, P, i, 0))
                    return true;
            }

            return false;
        }

        static bool matchRegex(string[] G, string[] P, int gRow, int pRow)
        {
            string pt = string.Format("{0}(?={1})", P[pRow][0], P[pRow].Substring(1));

            MatchCollection matches = Regex.Matches(G[gRow], pt);
            foreach (Match m in matches)
            { 
                if (matchPatternAtIndex(G, P, gRow + 1, pRow + 1, m.Index))
                    return true;
            }
            return false;
        }
        //static bool matchRegex(string[] G, string[] P, int gRow, int pRow)
        //{
        //    Match m = Regex.Match(G[gRow], P[pRow]);
        //    int index = 0;
        //    while(m.Success)
        //    {
        //        if (matchPatternAtIndex(G, P, gRow + 1, pRow + 1, index + m.Index))
        //            return true;

        //        index += m.Index + 1;
        //        if (index + P[pRow].Length > G[gRow].Length)
        //            break;
        //        m = Regex.Match(G[gRow].Substring(index), P[pRow]);
                
        //    }
        //    return false;
        //}

        static bool matchPatternAtIndex(string[] G, string[] P, int gRow, int pRow, int index)
        {
            if (pRow == P.Length)
                return true;

            if (gRow == G.Length)
                return false;

            if(G[gRow].Substring(index, P[pRow].Length) == P[pRow])
            {
                if (matchPatternAtIndex(G, P, gRow + 1, pRow + 1, index))
                    return true;
            }
            return false;
        }
    }

    //string pattern = string.Format("{0}", P[pRow]);
    //MatchCollection matches = Regex.Matches(G[gRow], pattern);
    //MatchCollection matches = Regex.Matches(G[gRow], P[pRow]);

    //foreach (Match m in matches)
    //{
    //    res = matchRegex(G, P, gRow + 1, pRow + 1, gLenght, pLenght);
    //    if (res == m.Index || res == -2)
    //        return m.Index;
    //}

}
