using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHackerRankCity2
{
    class Program
    {
        static long mod = 1000000007;

        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(sol(n, A));
            Console.ReadLine();
        }

        static long sol(int n, int[] A)
        {
            long sum = 0;
            long distance = 0;
            long count = 1;
            long distance1stG = 0;
            long distance1stGPlus1 = 0;
            long distance2N = 0;
            long groupCount = 0;

            for (int i = 0; i < n; i++)
            {
                distance1stG = distance;
                groupCount = count;

                long[] SD = addNode(distance, sum, count, A[i]);//add node
                sum = SD[0];
                distance = SD[1];

                distance1stGPlus1 = distance;

                sum = mirror(distance, sum, count);//mirror
                count = count * 2 + 1;
                distance *= 2;

                SD = addNode(distance, sum, count, A[i]);//add node
                sum = SD[0];
                distance = SD[1];
                sum = mirror(distance, sum, count);//mirror

                distance2N = distance;

                sum = deleteNode(distance, sum, count, A[i]);//delete middle node

                count = count * 2;
                distance = finalDistance(distance2N, distance1stG, distance1stGPlus1, groupCount, count);
            }

            return sum;
        }

        static long finalDistance(long D2n, long D1G, long D1Gp1, long GC, long TC)
        {
            
            long res = (D2n + D1Gp1) % mod;
            res = (res + D1G) % mod;
            res = (res + (D1Gp1 * (TC - GC) % mod)) % mod;

            return res;
        }

        static long deleteNode(long currentDist, long sum, long amountToMirrow, int distance)
        {
            long res = (currentDist * 2) % mod;
            long amount2 = (amountToMirrow * amountToMirrow) % mod;
            amount2 = (amount2 * distance) % mod;
            return sum - res - amount2;
        }

        static long mirror(long currentDist, long sum, long amountToMirrow)
        {
            long res = (currentDist * amountToMirrow) % mod;
            res = res * 2 % mod;
            long sm = sum * 2 % mod;
            res = (res + sm) % mod;
            return res;
        }

        static long[] addNode(long currentDist, long sum, long amountToMirrow, int distance)
        {
            long dt = distance * amountToMirrow % mod;

            currentDist = (currentDist + dt) % mod;
            sum = (currentDist + sum) % mod;

            return new long[] { sum, currentDist };
        }
    }
}
