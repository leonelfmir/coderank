using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPCointOnTheTable
{
    class Program
    {
        static void Main(string[] args)
        {
            //readfile
            string path = "00";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");

            int[] NMK = Array.ConvertAll(lines[0].Split(' '), int.Parse);
            int n = NMK[0], m = NMK[1], k = NMK[2];
            string[] Table = new string[n];

            for (int i = 1; i < n; i++)
            {
                Table[i - 1] = lines[i];
            }

            //System.IO.File.WriteAllText("Output" + path + ".txt");
        }

        static int sol(string[] table, int n, int m, int k, int[] xPos)
        {
            Cell[,] dist = new Cell[n, m];

            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m; c++)
                {
                    dist[r, c] = new Cell { value = table[r][c] };
                }
            }



        }

        class Cell
        {
            public bool visited = false;
            public int dist = 0;
            public char value = 'x';
            public bool finishes = false;
            public int distX = 0;
        }

        static Cell getDist(int x, int y, Cell[,] dist, int n, int m, int[] Xpos)
        {
            if (x == n || y == m)
                return new Cell();

            if (dist[x, y].visited)
            {
                return dist[x, y];
            }

            dist[x, y].visited = true;
            Cell tempcell = new Cell();
            switch (dist[x, y].value)
            {
                case 'R':
                    tempcell = getDist(x, y + 1, dist, n, m, Xpos);
                    break;
                case 'L':
                    tempcell = getDist(x, y + 1, dist, n, m, Xpos);
                    break;
                case 'U':
                    tempcell = getDist(x, y + 1, dist, n, m, Xpos);
                    break;
                case 'D':
                    tempcell = getDist(x, y + 1, dist, n, m, Xpos);
                    break;
                default:
                    dist[x,y].visited = true;
                    dist[x, y].finishes = true;
                    return tempcell;
            }


            if(tempcell.finishes)
            {
                dist[x, y].dist = tempcell.dist + 1;
            }

            dist[x, y].finishes = tempcell.finishes;
            dist[x, y].distX = Math.Abs(Xpos[0] - x) + Math.Abs(Xpos[1] - y);
            
            return dist[x, y];
        }
    }
}
