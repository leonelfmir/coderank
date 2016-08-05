using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPGridWalking5
{
    class Program
    {
        static void Main(string[] args)
        {
            cnk = nk(300 + 1);

            string path = "00";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            int j = 0;
            int ij = int.Parse(lines[j++]);

            for (int i = 0; i < ij; i++)
            {
                int[] NM = Array.ConvertAll(lines[j++].Split(' '), int.Parse);
                int N = NM[0];//dimensions
                int M = NM[1];//steps
                int[] X = Array.ConvertAll(lines[j++].Split(' '), int.Parse);
                int[] D = Array.ConvertAll(lines[j++].Split(' '), int.Parse);
                Console.WriteLine(sol(N, M, X, D));
            }

            Console.Read();
        }

        static long[,] cnk;
        static int modulo = 1000000007;

        static long[,] nk(int size)
        {
            long[,] choose = new long[size, size];

            for (int r = 0; r < size; r++)
            {

                choose[r, 0] = choose[r, r] = 1;

                for (int c = 1; c < r; c++)
                {

                    choose[r, c] = (choose[r - 1, c - 1] + choose[r - 1, c]) % modulo;
                }
            }

            return choose;
        }

        static long sol(int N, int M, int[] X, int[] D)
        {
            Dictionary<Tuple<int, int, int>, long> dic = new Dictionary<Tuple<int, int, int>, long>();//pos, posmax, steps
            long[,] combinePaths = new long[N, M + 1];


            for (int n = 0; n < N; n++)
            {

                for (int m = 0; m <= M; m++)//steps
                {
                    combinePaths[n, m] = stepsOneD(X[n], D[n], m, dic);
                }
            }

            long[,] pathsIntegration = new long[N + 1, M + 1];

            // Base cases

            for (int m = 0; m <= M; m++)
                pathsIntegration[0, m] = 1L;

            for (int n = 0; n <= N; n++)
                    pathsIntegration[n, 0] = 1L;

                for (int m = 1; m <= M; m++)
                pathsIntegration[1, m] = combinePaths[0, m];

            // Recurrence relation

            for (int d = 2; d <= N; d++)
            {
                for (int m = 1; m <= M; m++)
                {

                    long result = 0;

                    for (int i = 0; i <= m; i++)
                    {

                        long binomialMod = cnk[m, i];
                        long operand1 = pathsIntegration[d - 1, i];
                        long operand2 = combinePaths[d - 1, m - i];

                        long prod1 = (binomialMod * operand1) % modulo;
                        long prod2 = (prod1 * operand2) % modulo;

                        result += prod2;
                    }

                    pathsIntegration[d, m] = result % modulo;
                }
            }

            return pathsIntegration[N,M];

        }

        static long stepsOneD(int pos, int posMax, int steps, Dictionary<Tuple<int, int, int>, long> dic)
        {
            Tuple<int, int, int> tempT = new Tuple<int, int, int>(pos, posMax, steps);
            //if (pos == 3)
            //    pos = 3;

            if (dic.ContainsKey(tempT))
                return dic[tempT];

            if (steps == 0)
                return dic[tempT] = 1;

            long res = 0;

            if (pos > 1)
                res += stepsOneD(pos - 1, posMax, steps - 1, dic);

            if (pos < posMax)
                res += stepsOneD(pos + 1, posMax, steps - 1, dic);

            return dic[tempT] = res % modulo;
        }
    }
}
