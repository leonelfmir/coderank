using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "10";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");

            string[] rcn = lines[0].Split(' ');
            int r = int.Parse(rcn[0]);
            int c = int.Parse(rcn[1]);
            long n = long.Parse(rcn[2]);
            string[] rows = new string[r];
            for (int i = 1; i <= r; i++)
            {
                rows[i - 1] = lines[i];
            }

            for (long i = 2; i < 20; i++)
            {
                System.IO.File.WriteAllText("Output" + path + "T" + i.ToString().PadLeft(5, '0') + ".txt", grid(rows, r, c, i));
            }
            
            //while (true)
            //{
            //    string[] rcn = Console.ReadLine().Split(' ');
            //    int r = int.Parse(rcn[0]);
            //    int c = int.Parse(rcn[1]);
            //    long n = long.Parse(rcn[2]);
            //    string[] rows = new string[r];
            //    for (int i = 0; i < r; i++)
            //    {
            //        rows[i] = Console.ReadLine();
            //    }

            //    char[,] G = grid(rows, r, c, n);
            //    printG(G);
            //}
        }

        static string grid(string[] rows, int R, int C, long n)
        {
            char[,] G = new char[R, C];
            HashSet<Tuple<int, int>>[] bombs = new HashSet<Tuple<int, int>>[2];
            bombs[0] = new HashSet<Tuple<int, int>>();
            bombs[1] = new HashSet<Tuple<int, int>>();

            //HashSet<Tuple<int, int>> bombs2 = new HashSet<Tuple<int, int>>();
            Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> D = new Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>>();

            //fill bombs array
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (rows[r][c] == 'O')
                        bombs[0].Add(new Tuple<int, int>(r, c));
                }
            }

            //if (n == 1)
            //{
            //    G = fillChar(R, C, bombs, false);
            //}
            //else
            //{
            //    //n = (n - 1) % 4;
            //    if ((n & 1) == 0)
            //    {
            //        G = fillChar(R, C, bombs, true); //return fill chart, all bombs
            //        //printG(G);
            //    }
            //    else
            //    {
                    int group = 0;
                    for(int i = 2; i <= n; i++)
                    {
                        if ((i & 1) == 0)
                        {
                            
                            fillOtherBombsGroup(R, C, bombs, group);
                            group = group == 0 ? 1 : 0;
                     }
                        else
                        {

                            Explosion(R, C, bombs, group == 0 ? 1 : 0, D);
                            //test
                        }

                        //G = fillChar(R, C, bombs, false);
                        //printG(G);
                    }
            //    }
            //}
            G = fillChar(R, C, bombs, false);
            return printG(G);
        }

        static char[,] fillChar(int R, int C, HashSet<Tuple<int, int>>[] bombs, bool allBombs)
        {
            char[,] G = new char[R, C];

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (allBombs || bombs[0].Contains(new Tuple<int, int>(r, c)) || bombs[1].Contains(new Tuple<int, int>(r, c)))
                        G[r, c] = 'O';
                    else
                        G[r, c] = '.';
                }
            }

            return G;

        }

        static void Explosion(int R, int C, HashSet<Tuple<int, int>>[] bombs, int bombGroup, Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> D)
        {
            //HashSet<Tuple<int, int>> temp = new HashSet<Tuple<int, int>>();
            var exploting = bombs[bombGroup];
            var notExploting = bombs[(bombGroup + 1) % 2];

            //bombs explode
            foreach (var item in exploting)
            {
                if (!D.ContainsKey(item))
                {
                    D[item] = new HashSet<Tuple<int, int>>();

                    D[item].Add(item);
                    //up dow left righ
                    if (item.Item1 > 0)
                        D[item].Add(new Tuple<int, int>(item.Item1 - 1, item.Item2));
                    if (item.Item1 < R - 1)
                        D[item].Add(new Tuple<int, int>(item.Item1 + 1, item.Item2));
                    if (item.Item2 > 0)
                        D[item].Add(new Tuple<int, int>(item.Item1, item.Item2 - 1));
                    if (item.Item1 < C - 1)
                        D[item].Add(new Tuple<int, int>(item.Item1, item.Item2 + 1));

                }

                foreach (var item1 in D[item])
                {
                    if (notExploting.Contains(item1))
                        notExploting.Remove(item1);
                }


            }

            bombs[bombGroup].Clear();
        }

        static string printG(char[,] G)
        {
            StringBuilder res = new StringBuilder();

            //Console.WriteLine("CHAR---------------------");
            for (int r = 0; r < G.GetLength(0); r++)
            {
                for (int c = 0; c < G.GetLength(1); c++)
                {
                    res.Append(G[r, c]);
                }
                res.Append("\n");
            }

            return res.ToString();
        }

        static void fillOtherBombsGroup(int R, int C, HashSet<Tuple<int, int>>[] bombs, int bombGroup)
        {
            var oldG = bombs[bombGroup];
            var newG = bombs[(bombGroup + 1) % 2];

            Tuple<int, int> tempT;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    tempT = new Tuple<int, int>(r, c);
                    if (!oldG.Contains(tempT))
                        newG.Add(tempT);
                }
            }
        }



    }
}
