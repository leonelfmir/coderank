using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(string[] args)
    {
        Dictionary<Tuple<int, int, int>, long> dic = new Dictionary<Tuple<int, int, int>, long>();//pos, posmax, steps
        pascalsTriangle = nk(300 + 1);

        int t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            int[] NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int N = NM[0];//dimensions
            int M = NM[1];//steps
            int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] D = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(sol(N, M, X, D, dic));
        }
    }

    static int modulo = 1000000007;
    static long[,] pascalsTriangle;

    static long sol(int N, int M, int[] X, int[] D, Dictionary<Tuple<int, int, int>, long> dic)
    {
        Dictionary<string, long> kncs = new Dictionary<string, long>();

        long res = 0;
        List<List<int>> comb = new List<List<int>>();

        forHelper(D, N - 1, M, new List<int>(), comb);

        foreach (List<int> li in comb)
        {
            long sm = sums(M, N, X, D, dic, li, kncs);
            res = (res + sm) % modulo;

        }

        return res;
    }

    static long sums(int M, int N, int[] X, int[] D, Dictionary<Tuple<int, int, int>, long> dic, List<int> L, Dictionary<string, long> kncs)
    {
        string key = string.Join(",", L);

        if (kncs.ContainsKey(key))
            return kncs[key];

        long res = 1;
        long ways = 0;
        int stepsLeft = M;
        for (int i = 0; i < L.Count; i++)
        {
            ways = stepsOneD(X[i], D[i], L[i], dic);
            res = res * ways % modulo;
            res = (res * Cnk(stepsLeft, L[i])) % modulo;
            stepsLeft -= L[i];
        }

        return kncs[key] = res;
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

    static long Cnk(int n, int k)
    {
        return pascalsTriangle[n, k];
    }

    static void forHelper(int[] D, int dim, int number, List<int> L, List<List<int>> res)
    {
        if (dim == 0 || number == 0)
        {
            L.Add(number);
            res.Add(L);
        }
        else
        {
            List<int> temp = new List<int>();

            for (int j = 0; j <= number; j++)
            {
                temp = new List<int>(L);
                temp.Add(j);
                forHelper(D, dim - 1, number - j, temp, res);
            }
        }

    }

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
}