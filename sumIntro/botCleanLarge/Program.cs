using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace botCleanLarge
{
    class Program
    {
        enum Action { UP, DOWN, LEFT, RIGHT, CLEAN };

        static void next_move(int posr, int posc, int dimh, int dimw, String[] board)
        {
            //add logic here
            string dirty = "d";

            if (board[posr][posc] == dirty[0])
            {
                Console.WriteLine("CLEAN");
                return;
            }

            int[] closestDirtyCell = new int[2];
            int minDist = dimh * dimw;
            int minDistTemp = 0;
            for (int r = 0; r < dimh; r++)
            {
                if (board[r].Contains(dirty))
                {
                    for (int c = board[r].IndexOf(dirty); c < dimw; c++)
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
                Console.WriteLine(left ? Action.LEFT.ToString() : Action.RIGHT.ToString());
            }
            else if (posr != closestDirtyCell[0])
            {
                posr += down ? 1 : -1;
                Console.WriteLine(down ? Action.DOWN.ToString() : Action.UP.ToString());
            }
        }
        static void Main(String[] args)
        {
            String temp = Console.ReadLine();
            String[] position = temp.Split(' ');
            int[] pos = new int[2];
            for (int i = 0; i < 2; i++) pos[i] = Convert.ToInt32(position[i]);
            String[] dimension = Console.ReadLine().Split(' ');
            int[] dim = new int[2];
            for (int i = 0; i < 2; i++) dim[i] = Convert.ToInt32(dimension[i]);
            String[] board = new String[dim[0]];
            for (int i = 0; i < dim[0]; i++)
            {
                board[i] = Console.ReadLine();
            }
            next_move(pos[0], pos[1], dim[0], dim[1], board);
        }
    }
}
