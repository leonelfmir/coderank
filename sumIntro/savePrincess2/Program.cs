using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace savePrincess2
{
    class Program
    {
        static void nextMove(int n, int r, int c, String[] grid)
        {
            string princess = "p";
            int mr = r;
            int mc = c;

            int pr = 0;
            int pc = 0;

            for (; pr < n; pr++)
            {
                if(grid[pr].Contains(princess))
                {
                    pc = grid[pr].IndexOf(princess);
                    break;
                }
            }

            bool down = mr < pr;
            bool left = mc > pc;

            //while (mr != pr || mc!= pc)
            //{
                if(mr != pr)
                {
                    mr += down ? 1 : -1;
                    Console.WriteLine(down ? "DOWN" : "UP");
                }
                else if (mc != pc)
                {
                    mc += left ? -1 : 1;
                    Console.WriteLine(left ? "LEFT" : "RIGHT");
                }

            //}
        }
        static void Main(String[] args)
        {
            int n;

            n = int.Parse(Console.ReadLine());
            String pos;
            pos = Console.ReadLine();
            String[] position = pos.Split(' ');
            int[] int_pos = new int[2];
            int_pos[0] = Convert.ToInt32(position[0]);
            int_pos[1] = Convert.ToInt32(position[1]);
            String[] grid = new String[n];
            for (int i = 0; i < n; i++)
            {
                grid[i] = Console.ReadLine();
            }

            nextMove(n, int_pos[0], int_pos[1], grid);

        }
    }
}
