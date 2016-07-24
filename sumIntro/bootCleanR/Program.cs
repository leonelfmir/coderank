using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootCleanR
{
    class Program
    {
        static void nextMove(int posr, int posc, String[] board)
        {
            //add logic here
            string dirty = "d";

            if (board[posr][posc] == dirty[0])
            {
                Console.WriteLine("CLEAN");
                return;
            }

            int[] dirtyCell = new int[2];
            for (int r = 0; r < board.Length; r++)
            {
                if (board[r].Contains(dirty))
                {
                    dirtyCell[0] = r;
                    dirtyCell[1] = board[r].IndexOf(dirty);
                }

            }

            bool down = posr < dirtyCell[0];
            bool left = posc > dirtyCell[1];

            if (posc != dirtyCell[1])
            {
                posc += left ? -1 : 1;
                Console.WriteLine(left ? "LEFT" : "RIGHT");
            }
            else if (posr != dirtyCell[0])
            {
                posr += down ? 1 : -1;
                Console.WriteLine(down ? "DOWN" : "UP");
            }
        }
        static void Main(String[] args)
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            int[] pos = new int[2];
            String[] board = new String[5];
            for (int i = 0; i < 5; i++)
            {
                board[i] = Console.ReadLine();
            }
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            nextMove(pos[0], pos[1], board);
        }
    }
}
