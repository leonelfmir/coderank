using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aChessBoardGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimension = 15;
            bool?[,] table = new bool?[dimension, dimension];

            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] p = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

                Console.WriteLine("{0}", winner(p[0] - 1, p[1]- 1, dimension, table) ? "Second" : "First");
            }

            printTable(table, dimension);
            Console.Read();
        }

        static void printTable(bool?[,] table, int dimension)
        {
            for (int r = 0; r < dimension; r++)
            {
                Console.WriteLine();
                for (int c = 0; c < dimension; c++)
                {
                    Console.Write("{0} ", table[r, c] == true ? 'X' : table[r, c] == null ? 'N': 'O');
                }
            }
        }

        static bool winner(int R, int C, int dimension, bool?[,] table)
        {
            table[0, 0] = table[0, 1] = table[1, 0] = table[1, 1] = true;

            return winingCell(R, C, table, dimension);
        }

        static bool winingCell(int r, int c, bool?[,] table, int dimension)
        {
            bool winner = true;
            if(table[r,c] == null)
            {
                foreach (var item in positions(r,c,dimension))
                {
                    if (winingCell(item[0], item[1], table, dimension) == true)
                    {
                        winner = false;
                        break;
                    }
                }

                table[r, c] = winner;
            }

            return table[r, c] ?? false; 
        }

        static List<int[]> positions(int r, int c, int dimension)
        {
            List<int[]> res = new List<int[]>();
            //l2
            if (c - 2 >= 0)
            {
                //l2u1
                if (r - 1 >= 0)
                    res.Add(new int[] { r - 1, c - 2 });
                //l2d1
                if (r + 1 < dimension)
                    res.Add(new int[] { r + 1, c - 2 });
            }
            //u2
            if (r - 2 >= 0)
            {
                //u2l1
                if (c - 1 >= 0)
                    res.Add(new int[] { r - 2, c - 1 });
                //u2r1
                if (c + 1 < dimension)
                    res.Add(new int[] { r - 2, c + 1 });
            }

            return res;
        }
    }
}
