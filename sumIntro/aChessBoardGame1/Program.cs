using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aChessBoardGame1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Tuple<int, int>, bool> dp = new Dictionary<Tuple<int, int>, bool>();
            
            Console.WriteLine(winner(8, 8, dp));

            int dimension = 15+1;
            char[][] table = new char[dimension][];

            for (int i = 0; i < dimension; i++)
            {
                table[i] = new char[dimension];
            }

            foreach(KeyValuePair<Tuple<int, int>, bool> kv in dp)
            {
                table[kv.Key.Item1][kv.Key.Item2] = kv.Value?'x':'o';
            };

            int line = 0;
            foreach (var item in table)
            {
                Console.WriteLine(line++.ToString().PadLeft(2) + string.Join("  ", item));
            }
            Console.WriteLine("".PadLeft(5) + string.Join("  ", Enumerable.Range(1,15)));


            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                Console.WriteLine("{0}", winner(p[0], p[1], dp)? "First" : "Second");
            }

            Console.Read();
        }

        

        static bool winner(int R, int C, Dictionary<Tuple<int, int>, bool> dp)
        {
            //winnning positions
            dp[new Tuple<int, int>(1, 1)] = true;
            dp[new Tuple<int, int>(1, 2)] = true;
            dp[new Tuple<int, int>(2, 1)] = true;
            dp[new Tuple<int, int>(2, 2)] = true;

            Queue<Tuple<int, int>> toVisit = new Queue<Tuple<int, int>>();
            HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();

            foreach (Tuple<int, int> vl in dp.Keys)
            {
                toVisit.Enqueue(vl);
            }

            Tuple<int, int> current;
            //int r = 0;
            //int c = 0;
            while (toVisit.Count > 0)
            {
                //Console.WriteLine(string.Join(" - ", dp.Keys.Select(x => string.Join(",", x))));
                current = toVisit.Dequeue();
                if (visited.Contains(current))
                    continue;

                visited.Add(current);

                foreach (var pos in positions(current))
                {
                    //winning position
                    if (dp[current])
                    {
                        dp[pos] = false;
                    }
                    else
                    {
                        if (!dp.ContainsKey(pos))
                        {
                            dp[pos] = true;
                        }
                    }

                    if (!visited.Contains(pos))
                        toVisit.Enqueue(pos);
                }
            }

            return dp[new Tuple<int, int>(R, C)];
        }

        static List<Tuple<int, int>> positions(Tuple<int, int> pos)
        {
            List<Tuple<int, int>> res = new List<Tuple<int, int>>();
            int r = pos.Item1;
            int c = pos.Item2;

            //r2
            if (c + 2 <= 15)
            {
                //r2u1
                if (r - 1 > 0)
                    res.Add(new Tuple<int, int>(r - 1, c + 2));
                //r2d1
                if (r + 1 <= 15)
                    res.Add(new Tuple<int, int>(r + 1, c + 2));
            }
            //d2
            if (r + 2 <= 15)
            {
                //d2l1
                if (c - 1 > 0)
                    res.Add(new Tuple<int, int>(r + 2, c + -1));
                //d2r1
                if (c + 1 <= 15)
                    res.Add(new Tuple<int, int>(r + 2, c + 1));
            }

            return res;
        }

        //static bool[,] tablePos(int n, List<int[]> losers)
        //{
        //    bool?[,] table = new bool?[n, n];

        //    foreach (var item in losers)
        //    {
        //        table[item[0], item[1]] = true;
        //    }

        //    for (int r = 0; r < n; r++)
        //    {
        //        for (int c = 0; c < n; c++)
        //        {
        //            if (table[r, c])
        //            {
        //                if (r + 2 < n)
        //                {
        //                    if (c + 1 < n)
        //                        table[r, n] = false;
        //                }
        //            }
        //        }
        //    }

        //}

        //static bool winner(int R, int C)
        //{
        //    int dimensions = 15;
        //    bool?[,] dp = new bool?[dimensions, dimensions];

        //    //winnning positions
        //    dp[1, 1] = true;
        //    dp[1, 2] = true;
        //    dp[2, 1] = true;
        //    dp[2, 2] = true;

        //    Queue<Tuple<int, int>> toVisit = new Queue<Tuple<int, int>>();
        //    HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();

        //    foreach (Tuple<int, int> vl in dp.Keys)
        //    {
        //        toVisit.Enqueue(vl);
        //    }

        //    Tuple<int, int> current;
        //    //int r = 0;
        //    //int c = 0;
        //    while (toVisit.Count > 0)
        //    {
        //        //Console.WriteLine(string.Join(" - ", dp.Keys.Select(x => string.Join(",", x))));
        //        current = toVisit.Dequeue();
        //        if (visited.Contains(current))
        //            continue;

        //        visited.Add(current);

        //        foreach (var pos in positions(current))
        //        {
        //            //winning position
        //            if (dp[current])
        //            {
        //                dp[pos] = false;
        //            }
        //            else
        //            {
        //                if (!dp.ContainsKey(pos))
        //                {
        //                    dp[pos] = true;
        //                }
        //            }

        //            if (!visited.Contains(pos))
        //                toVisit.Enqueue(pos);
        //        }
        //    }

        //    return true;
        //}

        //static List<Tuple<int, int>> positions(Tuple<int, int> pos)
        //{
        //    List<Tuple<int, int>> res = new List<Tuple<int, int>>();
        //    int r = pos.Item1;
        //    int c = pos.Item2;

        //    //r2
        //    if (c + 2 <= 15)
        //    {
        //        //r2u1
        //        if (r - 1 > 0)
        //            res.Add(new Tuple<int, int>(r - 1, c + 2));
        //        //r2d1
        //        if (r + 1 <= 15)
        //            res.Add(new Tuple<int, int>(r + 1, c + 2));
        //    }
        //    //d2
        //    if (r + 2 <= 15)
        //    {
        //        //d2l1
        //        if (c - 1 > 0)
        //            res.Add(new Tuple<int, int>(r + 2, c + -1));
        //        //d2r1
        //        if (c + 1 <= 15)
        //            res.Add(new Tuple<int, int>(r + 2, c + 1));
        //    }

        //    return res;
        //}

        //static int winner(int r, int c)
        //{
        //    int diag = c - r;
        //    int moves = 0;

        //    while (diag < -1 || diag > 1)
        //    {
        //        if (diag < 0)
        //        {
        //            r -= 2;
        //            c += 1;
        //            diag += 2;
        //        }
        //        else
        //        {
        //            r += 1;
        //            c -= 2;
        //            diag -= 2;
        //        }

        //        moves++;
        //    }

        //    moves = diag == 0 ? c - 1 : c;

        //    return ((moves & 1) == 1) ? 1 : 2;

        //}



        //static bool winnerDP(int r, int c, Dictionary<int[], bool> dp)
        //{



        //}


    }
}
