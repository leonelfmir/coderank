using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootClean
{
    class Program
    {
        static void next_move(int posr, int posc, String[] board)
        {
            //add logic here
            string dirty = "d";

            if (board[posr][posc] == dirty[0])
            {
                Console.WriteLine("CLEAN");
                return;
            }

            int[] closestDirtyCell = new int[2];
            int minDist = board.Length * board.Length;
            int minDistTemp = 0;
            for (int r = 0; r < board.Length; r++)
            {
                if (board[r].Contains(dirty))
                {
                    for (int c = board[r].IndexOf(dirty); c < board.Length; c++)
                    {
                        if (board[r][c] == dirty[0])
                        {

                            minDistTemp = Math.Abs(posr - r) + Math.Abs(posc - c);
                            if (minDistTemp < minDist)
                            {
                                closestDirtyCell[0] = r;
                                closestDirtyCell[1] = c;
                                minDist = minDistTemp;
                            }
                        }
                    }

                }
            }

            bool down = posr < closestDirtyCell[0];
            bool left = posc > closestDirtyCell[1];
            
            if (posc != closestDirtyCell[1])
            {
                posc += left ? -1 : 1;
                Console.WriteLine(left ? "LEFT" : "RIGHT");
            }
            else if (posr != closestDirtyCell[0])
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
            next_move(pos[0], pos[1], board);
        }
    }
}
