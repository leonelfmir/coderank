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
            pascalsTriangle = nk(300 + 1);

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

        static long[,] pascalsTriangle;
        static int modulo = 1000000007;

        static long[,] nk(int size)
        {
            long[,] choose = new long[size, size];

            for (int i = 0; i < size; i++)
            {

                choose[i, 0] = choose[i, i] = 1;

                for (int j = 1; j < i; j++)
                {

                    choose[i, j] = (choose[i - 1, j - 1] + choose[i - 1, j]) % modulo;
                }
            }

            return choose;
        }

        static long sol(int N, int M, int[] X, int[] D)
        {
            Dictionary<Tuple<int, int, int>, long> dic = new Dictionary<Tuple<int, int, int>, long>();//pos, posmax, steps

            long[][][] paths = new long[M][][];
            for (int steps = 0; steps < M; steps++)
            {
                paths[steps] = new long[N][];
                for (int dim = 0; dim < N; dim++)
                {
                    paths[steps][dim] = new long[D[dim]];
                    for (int pos = 0; pos < D[dim]; pos++)
                    {
                        paths[steps][dim][pos] = stepsOneD(pos, D[dim], steps, dic);
                    }
                }
            }

            Console.WriteLine(string.Join("\n", paths.Select(x => string.Join("\n", x.Select(string.Join("", x))));
            return 0;

        }

        static long stepsOneD(int pos, int posMax, int steps, Dictionary<Tuple<int, int, int>, long> dic)
        {
            Tuple<int, int, int> tempT = new Tuple<int, int, int>(pos, posMax, steps);

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
