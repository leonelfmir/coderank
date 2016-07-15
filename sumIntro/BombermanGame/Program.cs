using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombermanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] rcn = Console.ReadLine().Split(' ');
                int r = int.Parse(rcn[0]);
                int c = int.Parse(rcn[1]);
                long n = long.Parse(rcn[2]);
                string[] rows = new string[r];
                for (int i = 0; i < r; i++)
                {
                    rows[i] = Console.ReadLine();
                }

                char[,] G = grid(rows, r, c, n);
                printG(G);
            }
            Console.Read();

        }

        static char[,] grid(string[] rows, int R, int C, long n)
        {
            char[,] G = new char[R, C];
            HashSet<Tuple<int,int>> bombs = new HashSet<Tuple<int, int>>();
            HashSet<Tuple<int,int>> bombs2 = new HashSet<Tuple<int, int>>();
            Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> D = new Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>>();

            //fill bombs array
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (rows[r][c] == 'O')
                        bombs.Add(new Tuple<int, int>(r, c));
                }
            }

            if (n == 1 )
            {
                G = fillChar(R, C, bombs, false); 
            }
            else
            {
                n = (n - 1) % 4;
                if ((n & 1) == 1)
                {
                    G = fillChar(R, C, bombs, true); //return fill chart, all bombs
                }
                else
                {
                    if (n == 0)
                    {
                        //return first explosion
                        bombs = fillBombsArr(R, C, bombs);
                    }

                    var cellsBlank = cellsDestroyed(R, C, bombs, D);
                    G = fillCharBlanks(R, C, cellsBlank);
                }
            }
            
            return G;
        }

        static char[,] fillChar(int R, int C, HashSet<Tuple<int, int>> bombs, bool allBombs)
        {
            char[,] G = new char[R, C];

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if(allBombs || bombs.Contains(new Tuple<int, int>(r,c)))
                        G[r, c] = 'O';
                    else
                        G[r, c] = '.';
                }
            }

            return G;

        }

        static char[,] fillCharBlanks(int R, int C, HashSet<Tuple<int, int>> blank)
        {
            char[,] G = new char[R, C];

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (blank.Contains(new Tuple<int, int>(r, c)))
                        G[r, c] = '.';
                    else
                        G[r, c] = 'O';
                }
            }

            return G;

        }

        static char[,] fillCharBombs(int R, int C, HashSet<Tuple<int, int>> blank)
        {
            char[,] G = new char[R, C];

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (!blank.Contains(new Tuple<int, int>(r, c)))
                        G[r, c] = '.';
                    else
                        G[r, c] = 'O';
                }
            }

            return G;

        }

        static HashSet<Tuple<int, int>> fillBombsArr(int R, int C, HashSet<Tuple<int, int>> bombs)
        {
            HashSet<Tuple<int, int>> temp = new HashSet<Tuple<int, int>>();

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    Tuple<int, int> tempT = new Tuple<int, int>(r, c);
                    if (!bombs.Contains(tempT))
                        temp.Add(tempT);
                }
            }

            return temp;
        }

        static HashSet<Tuple<int, int>> cellsDestroyed(int R, int C, HashSet<Tuple<int, int>> bombs, Dictionary<Tuple<int, int>, HashSet<Tuple<int, int>>> D)
        {
            HashSet<Tuple<int, int>> temp = new HashSet<Tuple<int, int>>();

            foreach (var item in bombs)
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
                    temp.Add(item1);
                }
            }
            return temp;
        }

        static void printG(char[,] G)
        {
            for (int r = 0; r < G.GetLength(0); r++)
            {
                for (int c = 0; c < G.GetLength(1); c++)
                {
                    Console.Write(G[r, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
