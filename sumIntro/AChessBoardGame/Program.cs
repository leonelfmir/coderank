using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AChessBoardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int[] p1 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                int[] p2 = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);


                Console.WriteLine(winner(p1, p2));
            }

            Console.Read();
        }

        static int winner(int[] p1, int[] p2)
        {
            int[][] poss = { p1, p2 };
            int[] moves = new int[2];
            int[] diag = new int[2];

            for (int i = 0; i < 2; i++)
            {
                diag[i] = poss[i][1] - poss[i][0];

                while (diag[i] < -1 || diag[i] > 1)
                {
                    if (diag[i] < 0)
                    {
                        poss[i][0] -= 2;
                        poss[i][1] += 1;
                        diag[i] += 2;
                    }
                    else
                    {
                        poss[i][0] += 1;
                        poss[i][1] -= 2;
                        diag[i] -= 2;
                    }

                    moves[i]++;
                }

                if (diag[i] == 0)
                    moves[i] = poss[i][1] - 1;
            }

            return moves[0] < moves[1] ? 1 : 2;
        }
    }
}
