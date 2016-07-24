using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savePrincess
{
    class Program
    {
        static void displayPathtoPrincess(int n, string[] grid)
        {
            int mr = n / 2;
            int mc = mr;

            int pr = 0;
            int pc = 0;

            for (; pr < n; pr++)
            {
                if (grid[pr][0] == 'p')
                {
                    pc = 0;
                    break;
                }
                if( grid[pr][n-1] == 'p')
                {
                    pc = n - 1;
                    break;
                }

            }

            bool down = mr < pr;
            bool left = mc > pc;

            while (mr != pr)
            {
                mr += down ? 1 : -1;
                mc += left ? -1 : 1;

                Console.WriteLine(down ? "DOWN" : "UP");
                Console.WriteLine(left ? "LEFT" : "RIGHT");

            }


        }
        static void Main(String[] args)
        {
            int m;

            m = int.Parse(Console.ReadLine());

            String[] grid = new String[m];
            for (int i = 0; i < m; i++)
            {
                grid[i] = Console.ReadLine();
            }

            displayPathtoPrincess(m, grid);
        }
    }
}
