﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Roads_in_Hackerland
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            int n = A[0];
            int m = A[1];
            List<int[]> roads = new List<int[]>();
            for (int i = 0; i < m; i++)
            {
                roads.Add(Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse));
            }
            /*
                        string s = @"226 631 133

                        int[] A = Array.ConvertAll("900 1111".Split(' '), Int32.Parse);
                        int n = A[0];
                        int m = A[1];
                        List<int[]> roads = new List<int[]>();
                        string[] arrs = s.Split('\r');

                        for (int i = 0; i < m; i++)
                        {
                            roads.Add(Array.ConvertAll(arrs[i].Split(' '), Int32.Parse));
                        }*/

            Console.WriteLine(Distances(n,roads));
            Console.Read();




        }

        /*static int minDist(HashSet<int> Q, BigInteger?[] distance)
        {
            int firstNull = -1;
            int min = -1;
            foreach(int n in Q)
            {
                if (distance[n] == null && firstNull == -1)
                {
                    firstNull = n;
                    continue;
                }
                
                if(distance[n] != null && min == -1)
                {
                    min = n;
                    continue;
                }

                if (distance[n] != null && distance[n] < distance[min])
                {
                    min = n;
                }
            }

            return min == -1 ? firstNull : min;
        }*/
        /*static string Distances(int n, List<int[]> roads)
        {
            HashSet<int> Q = new HashSet<int>();

            Dictionary<int, List<int[]>> Graph = new Dictionary<int, List<int[]>>();

            foreach (int[] vl in roads)
            {
                if (!Graph.ContainsKey(vl[0]))
                    Graph[vl[0]] = new List<int[]>();

                if (!Graph.ContainsKey(vl[1]))
                    Graph[vl[1]] = new List<int[]>();

                Graph[vl[0]].Add(new int[] { vl[1], vl[2] });
                Graph[vl[1]].Add(new int[] { vl[0], vl[2] });

            }

            BigInteger?[] distance = new BigInteger?[n];
            int[] prev = new int[n];

            for(int i = 0; i < n; i++)
            {
                Q.Add(i);
            }

            distance[0] = 0;
            int vertex = 0;

            while (Q.Count > 0)
            {
                vertex = minDist(Q, distance);
                Q.Remove(vertex);

                foreach(int[] edge in Graph[vertex])
                {
                    BigInteger? alt = distance[vertex] + edge[1];
                    if (alt < distance[edge[0])
                    {
                        distance[edge[0]] = alt;
                        prev[edge[0]] = vertex;

                }
            }

        }*/

        static string Distances(int n, List<int[]> roads)
        {
            BigInteger?[,] mtx = new BigInteger?[n, n];

            foreach (int[] vl in roads)
            {
                mtx[vl[0] - 1, vl[1] - 1] = BigInteger.Pow(2,vl[2]);
                mtx[vl[1] - 1, vl[0] - 1] = BigInteger.Pow(2, vl[2]);
            }

            for (int k = 0; k < n; k++)
            {
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        if (r == c)
                            continue;
                        if (mtx[r, k] == null || mtx[k, c] == null)
                            continue;

                        var temp = mtx[r, k] + mtx[k, c];
                        if (mtx[r, c] == null || temp < mtx[r, c])
                        {
                            mtx[r, c] = temp;
                        }
                    }
                }
            }

            BigInteger res = 0;

            for (int r = 0; r < n; r++)
            {
                    for(int i = r+1; i < n; i++)
                    {
                        res += mtx[r, i] ?? 0;
                    }
            }

            StringBuilder sb = new StringBuilder();
            foreach(byte s in res.ToByteArray())
            {
                sb.Append(Convert.ToString(s,2).PadLeft(8, '0'));
            }

            string rs = sb.Length == 0 ? "0" : sb.ToString().TrimStart('0');

            return rs;
        }

        /*static string Distances(int n, List<int[]> roads)
        {
            BigInteger?[,] mtx = new BigInteger?[n, n];

            foreach (int[] vl in roads)
            {
                mtx[vl[0] - 1, vl[1] - 1] = BigInteger.Pow(2, vl[2]);
                mtx[vl[1] - 1, vl[0] - 1] = BigInteger.Pow(2, vl[2]);
            }

            printArr(mtx, n);
            for (int k = 0; k < n; k++)
            {
                for (int r = k+1; r < n; r++)
                {
                    for (int c = r+1; c < n; c++)
                    {
                        //if (r == c)
                        //    continue;
                        if (mtx[r, k] == null || mtx[k, c] == null)
                            continue;

                        var temp = mtx[r, k] + mtx[k, c];
                        if (mtx[r, c] == null || temp < mtx[r, c])
                        {
                            mtx[r, c] = temp;
                        }
                    }
                }
            }

            printArr(mtx, n);

            BigInteger res = 0;

            for (int r = 0; r < n; r++)
            {
                for (int i = r + 1; i < n; i++)
                {
                    res += mtx[r, i] ?? 0;
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (byte s in res.ToByteArray())
            {
                sb.Append(Convert.ToString(s, 2).PadLeft(8, '0'));
            }

            string rs = sb.Length == 0 ? "0" : sb.ToString().TrimStart('0');

            return rs;
        }*/

        static void printArr(BigInteger?[,] mtx, int n)
        {
            for (int r = 0; r < n; r++)
            {
                Console.WriteLine();
                for (int c = 0; c < n; c++)
                {
                    Console.Write(((mtx[r, c] ?? -1) + " ").PadLeft(4));
                }
            }

            Console.WriteLine();
        }
    }
}