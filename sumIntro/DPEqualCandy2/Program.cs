using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPEqualCandy2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] B = { 1, 5, 5 };
            Console.WriteLine(sol(B.Length, B));
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(sol(n, A));
            }

            Console.Read();
        }

        static int sol(int n, int[] A)
        {
            int res = 0;
            bool Change = true;
            while (Change)
            {
                Array.Sort(A);
                int i = 1;
                for (; i < n; i++)
                {
                    if (A[i - 1] < A[i])
                    {
                        int df = A[i] - A[i - 1];
                        res += getDiff(df, A, i, out Change);

                        if (Change)
                            break;
                    }

                }
                if (i == n)
                    Change = false;
            }

            return res;
        }

        static int getDiff(int diff, int[] A, int pos, out bool change)
        {
            int res = 0;
            int ch = 3;
            int[] chs = { 1, 2, 5 };
            int sum = 0;
            int mod = diff;
            int div = 0;

            if (diff > 4)
            {
                div = mod / chs[2];
                mod = mod % chs[2];
                res += div;
                sum = div * chs[2];
            }

            if(mod == 4)
            {
                res++;
                sum += 5;
                change = true;
            }
            else
            {
                change = false;
                for (int i = ch - 2; i >= 0; i--)
                {
                    div = mod / chs[i];
                    mod = mod % chs[i];
                    res += div;
                    sum += div * chs[i];
                }
            }

            addToArr(A, pos, sum);

            return res;

        }

        static void addToArr(int[] A, int pos, int amnt)
        {
            for (int i = 0; i < A.Length; i++)
            {
                if (i == pos)
                    continue;

                A[i] += amnt;
            }
        }
    }
}

