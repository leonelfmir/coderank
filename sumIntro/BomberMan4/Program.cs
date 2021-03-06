﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman4
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "05";
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


            System.IO.File.WriteAllText("Output" + path + ".txt", grid(rows, r, c, n));
            //Console.Read();

            //string[] rcn = Console.ReadLine().Split(' ');
            //int r = int.Parse(rcn[0]);
            //int c = int.Parse(rcn[1]);
            //long n = long.Parse(rcn[2]);
            //string[] rows = new string[r];
            //for (int i = 0; i < r; i++)
            //{
            //    rows[i] = Console.ReadLine();
            //}
            //grid(rows, r, c, n);

            //Console.Read();
        }

        static string grid(string[] rows, int R, int C, long n)
        {
            
            if (n == 1)//1
            {
                return string.Join("\n", rows);//initial config
            }
            
            if ((n & 1) == 0)
            {
                return string.Join("\n", Enumerable.Range(1, R).Select(x => new string('O', C))); //all bombs
            }
            else
            {
                //get repeated 3rd and 5th config
                n = n % 4;
                HashSet<Tuple<int, int>>[] bombs = new HashSet<Tuple<int, int>>[4];
                bombs[0] = new HashSet<Tuple<int, int>>();
                bombs[1] = new HashSet<Tuple<int, int>>();
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

                int group = 0;
                for (int i = 2; i <= 5; i++)
                {
                    if ((i & 1) == 0)
                    {

                        fillOtherBombsGroup(R, C, bombs, group);
                        group = group == 0 ? 1 : 0;
                    }
                    else
                    {
                        int p = 2;
                        p = i == 5 ? 3 : p;
                        Explosion(R, C, bombs, group == 0 ? 1 : 0, D);
                        bombs[p] = new HashSet<Tuple<int, int>>(bombs[group]);
                    }
                }

                char[][] G = new char[R][];
                //(3)
                if (n == 3)
                {
                    G = fillChar(R, C, bombs[2]);
                }//(5)
                else
                    G = fillChar(R, C, bombs[3]);

                string[] res = new string[R];
                for (int r = 0; r < R; r++)
                {
                    res[r] = new string(G[r]);
                }

                return string.Join("\n", res);
            }
        }

        static char[][] fillChar(int R, int C, HashSet<Tuple<int, int>> bombs)
        {
            char[][] G = new char[R][];

            for (int r = 0; r < R; r++)
            {
                G[r] = new char[C];
                for (int c = 0; c < C; c++)
                {
                    if (bombs.Contains(new Tuple<int, int>(r, c)))
                        G[r][c] = 'O';
                    else
                        G[r][c] = '.';
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
