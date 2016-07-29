using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPGridWalking
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "01";
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
            //int t = int.Parse(Console.ReadLine());
            //for (int i = 0; i < t; i++)
            //{
            //    int[] NM = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //    int N = NM[0];//dimensions
            //    int M = NM[1];//steps
            //    int[] X = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //    int[] D = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //    Console.WriteLine(sol(N, M, X, D));
            //}
        }

        static int modulo = 1000000007;

        static int sol(int N, int M, int[] X, int[] D)
        {
            Dictionary<int[], int> dic = new Dictionary<int[], int>(new IntArrayEqualityComparer());

            int[] stepsInDimension = new int[N];

            int res = stepsDims(D, M, X, dic);

            return res;
        }

        static int stepsDims(int[] D, int steps, int[] possitions, Dictionary<int[], int> dic)
        {

            if (steps == 0)
                return 1;

            int[] B = new int[possitions.Length + 1];
            possitions.CopyTo(B, 1);
            B[0] = steps;

            if (dic.ContainsKey(B))
                return dic[B]; 

            int N = D.Length;
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                //right
                count += possitions[i] < D[i] ? stepsDims(D, steps - 1, InDecrementArr(possitions, i, true), dic) : 0;
                //left
                count += possitions[i] > 1 ? stepsDims(D, steps - 1, InDecrementArr(possitions, i, false), dic): 0;
            }

            return dic[B] = count % modulo;
        }

        static int[] InDecrementArr(int[] A, int pos, bool increment)
        {
            int[] B = new int[A.Length];
            A.CopyTo(B, 0);
            if (increment)
                B[pos]++;
            else
                B[pos]--;
            return B;
        }

        //static int getStepsInDimension(int dim, int maxPos, int pos, int steps)
        //{
        //    Console.WriteLine(",({0},{1})", dim, pos);
        //    if (steps == 0)
        //    {
        //        Console.WriteLine("______________ = {0}", ++counter);
        //        return 0;
        //    }

        //    Tuple<int, int, int> key = new Tuple<int, int, int>(dim, pos, steps);
            
        //    //if (stepsD.ContainsKey(key))
        //    //    return stepsD[key];

        //    //int r = pos == maxPos ? 0 : getStepsInDimension(dim, maxPos, pos + 1, steps - 1) + 1;
        //    //int l = pos == 1?0: getStepsInDimension(dim, maxPos, pos - 1, steps - 1) + 1;

        //    int r = 0;
        //    int l = 0;

        //    if(pos < maxPos)
        //    {
        //        Console.Write("{2} - ({0},{1})", dim, pos, steps);
        //        r = getStepsInDimension(dim, maxPos, pos + 1, steps - 1) + 1;
        //    }

        //    if (pos > 0)
        //    {
        //        Console.Write("{2} - ({0},{1})", dim, pos, steps);
        //        r = getStepsInDimension(dim, maxPos, pos - 1, steps - 1) + 1;
        //    }

        //    return stepsD[key] = r + l;
        //}
    }

    public class IntArrayEqualityComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[] x, int[] y)
        {
            if (x.Length != y.Length)
            {
                return false;
            }
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    return false;
                }
            }
            return true;
        }

        public int GetHashCode(int[] obj)
        {
            int result = 17;
            for (int i = 0; i < obj.Length; i++)
            {
                unchecked
                {
                    result = result * 23 + obj[i];
                }
            }
            return result;
        }
    }
}
