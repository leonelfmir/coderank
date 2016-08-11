using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DPBricksGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                long[] A = Array.ConvertAll(Console.ReadLine().Split(' '), long.Parse);
                Console.WriteLine(sol(n, A));
            }

            Console.Read();
        }

        //static BigInteger sol(int n, long[] A)
        //{
        //    //Dictionary<int, long> D1 = new Dictionary<int, long>();
        //    //Dictionary<int, long> D2 = new Dictionary<int, long>();
        //    //Dictionary<int, long> D = new Dictionary<int, long>();

        //    Dictionary<int, BigInteger[]> D = new Dictionary<int, BigInteger[]>();
        //    return solve(n, A, D);
        //}

        ////static long solve1(int n, long[] A, int pos, bool p1, Dictionary<int, long> D1, Dictionary<int, long> D2)
        ////{
        ////    if (pos >= n)
        ////        return 0;

        ////    if (!D1.ContainsKey(pos))
        ////    {

        ////        int bricks = 3;
        ////        long[] sums = new long[bricks];
        ////        long[] adds = new long[bricks];
        ////        long max = 0;
        ////        int maxPos = 0;

        ////        for (int i = 0; i < bricks; i++)
        ////        {
        ////            if (pos + i < n)
        ////            {
        ////                sums[i] = solve(n, A, pos + i + 1, !p1, D1, D2);
        ////                adds[i] = (i == 0 ? 0 : sums[i - 1]) + A[pos + i];
        ////                sums[i] += adds[i];
        ////                if (sums[i] > max)
        ////                {
        ////                    max = sums[i];
        ////                    maxPos = i;
        ////                }
        ////            }
        ////        }

        ////        D1[n] = sums.Max();
        ////        D2[n] = D1[n] - adds[maxPos];
        ////    }
        ////    if (p1)
        ////        return D1[n];

        ////    return D2[n];
        ////}

        ////static long solve2(int n, long[] A, int pos, bool p1, Dictionary<int, long> D1, Dictionary<int, long> D2)
        ////{
        ////    if (pos >= n)
        ////        return 0;
            

        ////    if (!D1.ContainsKey(pos))
        ////    {

        ////        int bricks = 3;
        ////        long[] sums = new long[bricks];
        ////        long[] adds = new long[bricks];
        ////        long max = 0;
        ////        int maxPos = 0;

        ////        adds[0] = A[pos];
        ////        sums[0] = adds[0] + solve(n, A, pos + 1, !p1, D1, D2);
        ////        max = sums[0];
                
        ////        if (pos < n - 1)
        ////        {
        ////            adds[1] = adds[0] + A[pos + 1];
        ////            sums[1] = adds[1] + solve(n, A, pos + 2, !p1, D1, D2);
        ////            if(sums[1] > max)
        ////            {
        ////                max = sums[1];
        ////                maxPos = 1;
        ////            }
        ////        }
        ////        if (pos < n - 2)
        ////        {
        ////            adds[2] = adds[1] + A[pos + 2];
        ////            sums[2] = adds[2] + solve(n, A, pos + 3, !p1, D1, D2);
        ////            if (sums[2] > max)
        ////            {
        ////                max = sums[2];
        ////                maxPos = 2;
        ////            }
        ////        }

        ////        D1[n] = sums.Max();
        ////        D2[n] = D1[n] - adds[maxPos];
        ////    }
        ////    if (p1)
        ////        return D1[n];

        ////    return D2[n];
        ////}

        static BigInteger sol(int n, long[] A)
        {
            Dictionary<int, BigInteger[]> D = new Dictionary<int, BigInteger[]>();
            D[n] = new BigInteger[] { 0, 0 };

            BigInteger temp = 0;
            BigInteger sum = 0;
            int pos = 0;


            for (int i = n-1; i >= 0; i--)
            {
                D[i] = new BigInteger[] { 0, 0 };
                sum = 0;

                for (int j = 0; j < 3 && j + i < n; j++)
                {
                    pos = i + j;
                    sum += A[pos];
                    temp = sum + D[pos + 1][1];

                    if(temp > D[i][0])
                    {
                        D[i][0] = temp;
                        D[i][1] = D[pos + 1][0];
                    }
                }
            }

            return D[0][0];
        }
    }
}
