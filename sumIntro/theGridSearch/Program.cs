using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace theGridSearch
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
            BigInteger?[,] memo = new BigInteger?[R,C];
            BigInteger[] pt = Array.ConvertAll(P, BigInteger.Parse);

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (r > R - PR)
                        return false;

                    if (checkPattern(G, R, C, PR, PC, pt, memo, r, c))
                        return true;
                }
            }

            return false;          
        }

        static BigInteger? cell(string[] G, int R, int C, BigInteger?[,] memo, int size, int r, int c)
        {

            if (memo[r,c] != null)
                return memo[r,c];

            if (c < size)
            {
                if (c == size - 1)
                {
                    return memo[r, c] = BigInteger.Parse(G[r].Substring(0, c + 1));
                }

                return memo[r, c] = 0;
            }


            int start = int.Parse(G[r][c - size].ToString());
            int end = int.Parse(G[r][c].ToString());
            BigInteger pow = BigInteger.Pow(10, size - 1);
            BigInteger? res = memo[r, c] = ((cell(G, R, C, memo, size, r, c-1) ?? 0) - (start * pow)) * 10  + end;

            return res;
        }

        static bool checkPattern(string[] G, int R, int C, int PR, int PC, BigInteger[] pt, BigInteger?[,] memo, int r, int c)
        {
            for (int k = 0; k < PR; k++)
            {
                if (cell(G, R, C, memo, PC, r + k, c) != pt[k])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
