﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHackerRankCity
{
    class Program
    {
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
            long DI = D2n + D1Gp1;
            long res = DI + D1Gp1 * (TC - GC) + D1G;

            return res;
        }

        static long deleteNode(long currentDist, long sum, long amountToMirrow, int distance)
        {
            return sum - currentDist * 2 - amountToMirrow * amountToMirrow * distance;
        }

        static long mirror(long currentDist, long sum, long amountToMirrow)
        {
            sum = currentDist * amountToMirrow * 2 + sum * 2;
            return sum;
        }

        static long[] addNode(long currentDist, long sum, long amountToMirrow, int distance)
        {
            currentDist = currentDist + distance * amountToMirrow;
            sum = currentDist + sum;

            return new long[] { sum, currentDist };
        }

        

        //static long sol(int n, int[] A)
        //{

        //    Dictionary<long, long> points = new Dictionary<long, long>();
        //    HashSet<CP> CPS = new HashSet<CP>();
        //    //points[6] = 29;
        //    Queue<CP> Q = new Queue<CP>();
        //    Q.Enqueue(new CP(1));

        //    for (int i = 1; i <= n; i++)
        //    {

        //    }

        //}

        //static int step(int n, int[] A, Dictionary<long, long> points, HashSet<CP> CPS)
        //{

        //}
        //static long connect(int cp, int d, Dictionary<long, long> points)
        //{

        //}

    }

    //class CP
    //{
    //    public long number = 0;
    //    public bool[] cn = new bool[4];
    //    public long[] cnNumber = new long[4];

    //    public CP(long n)
    //    {
    //        number = n;
    //    }

    //}

}
