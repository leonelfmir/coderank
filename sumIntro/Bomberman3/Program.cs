using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman3
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "input10";
            string[] lines = System.IO.File.ReadAllLines(path + ".txt");

            string[] rcn = lines[0].Split(' ');
            int r = int.Parse(rcn[0]);
            int c = int.Parse(rcn[1]);
            long n = long.Parse(rcn[2]);
            string[] rows = new string[r];
            for (int i = 1; i <= r; i++)
            {
                rows[i-1] = lines[i];
            }


            System.IO.File.WriteAllText(path + "Output.txt", grid(rows, r, c, n));
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
            n = n % 4;

            if ((n & 1) == 0)
            {
                return string.Join("\n", Enumerable.Range(1,R).Select( x => new string('O',C))); //all bombs
            }
            else
            {
                if(n == 1)//1
                {
                    return string.Join("\n", rows);//initial config
                }
                else
                {
                    //second config (3)
                    char[][] G = fillChar(R, C, rows);

                    string[] res = new string[R];
                    for (int r = 0; r < R; r++)
                    {
                        res[r] = new string(G[r]);
                    }
                    
                    return string.Join("\n", res);
                }
            }
        }

        static char[][] fillChar(int R, int C, string[] rows)
        {
            char[][] G = new char[R][];

            for (int i = 0; i < R; i++)
            {
                G[i] = new char[C];
            }

            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (rows[r][c] == 'O')
                    {
                        G[r][c] = '.';

                        //up down left righ
                        if (r > 0)
                            G[r - 1][c] = '.';
                        if (r < R - 1)
                            G[r + 1][c] = '.';
                        if (c > 0)
                            G[r][c - 1] = '.';
                        if (c < C - 1)
                            G[r][c + 1] = '.';
                    }
                    else
                    {
                        if (G[r][c] != '.')
                            G[r][c] = 'O';
                    }
                }
            }
            return G;
        }
    }
}
