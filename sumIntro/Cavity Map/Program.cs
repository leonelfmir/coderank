using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cavity_Map
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] grid = new string[n];
            for (int grid_i = 0; grid_i < n; grid_i++)
            {
                grid[grid_i] = Console.ReadLine();
            }
            string[] res = reply(grid);

            foreach (string s in res)
            {
                Console.WriteLine(s);
            }

            Console.Read();
        }

        static string[] reply(string[] grid)
        {
            int ln = grid.Length;
            StringBuilder[] res = new StringBuilder[ln];

            for (int i = 0; i < ln ; i++)
            {
                res[i] = new StringBuilder();
                if (i == 0 || i == ln - 1)
                    res[i].Append(grid[i]);
                else
                {
                    for (int j = 0; j < grid[i].Length; j++)
                    {
                        if (j > 0 && j < grid[i].Length - 1 &&
                            grid[i][j] > grid[i][j - 1] && grid[i][j] > grid[i][j + 1] &&
                            grid[i][j] > grid[i - 1][j] && grid[i][j] > grid[i + 1][j])
                            res[i].Append("X");
                        else
                            res[i].Append(grid[i][j]);
                    }
                }
            }

            return Array.ConvertAll(res, x => x.ToString());
        }
    }
}
