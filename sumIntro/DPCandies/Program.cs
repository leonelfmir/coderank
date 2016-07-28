using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DPCandies
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = "11";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");

            int[] A = Array.ConvertAll(lines, int.Parse).Skip(1).ToArray();
            Console.WriteLine(sol(int.Parse(lines[0]), A));

            int t = int.Parse(Console.ReadLine());
            int[] n = new int[t];
            for (int i = 0; i < t; i++)
            {
                n[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine(sol(t, n));

        }

        static BigInteger sol(int t, int[] students)
        {
            SortedDictionary<int, HashSet<int>> D = new SortedDictionary<int, HashSet<int>>();
            int[] candies = new int[t];
            BigInteger candiesCount = 0;

            for (int i = 0; i < t; i++)
            {
                if (!D.ContainsKey(students[i]))
                    D[students[i]] = new HashSet<int>();

                D[students[i]].Add(i);
            }

            foreach (var item in D)
            {
                foreach(var h in item.Value)
                {
                    int lcan = h > 0 ? candies[h - 1] : 0;
                    int rcan = h < t-1 ? candies[h + 1] : 0;

                    int lran = h > 0 ? students[h - 1] : int.MaxValue;
                    int rran = h < t - 1 ? students[h + 1] : int.MaxValue;

                    if (lcan == 0 && rcan == 0)
                    {
                        candies[h] = 1;
                    }
                    else
                    {
                        //left candy, right no candy
                        if (lcan > 0 && rcan == 0)
                        {
                            if (lran < students[h])
                            {
                                candies[h] += lcan;
                            }
                            candies[h]++;
                        }
                        //left no candy, right candy
                        else if (lcan == 0 && rcan > 0)
                        {
                                candies[h] += rcan + 1;
                                //candiesCount += lcan + 1;
                        }
                        //left candy, right candy
                        else //if (lcan > 0 && rcan > 0)
                        {
                            if (lran < students[h])
                                candies[h] = Math.Max(lcan, rcan);
                            else
                                candies[h] = rcan;

                            candies[h]++;
                        }
                    }
                    candiesCount += candies[h];
                }
            }
            
            printArr(candies);
            return candiesCount;
        }

        static void printArr(int[] A)
        {
            string path = "11";
            System.IO.File.WriteAllText("Output" + path + ".txt", string.Join("\n", A));
            Console.WriteLine("Printed");
        }
    }
}
