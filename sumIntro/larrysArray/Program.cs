using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace larrysArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //string s = "9 8 10 7 3 5 2 11 4 6 1";
            //int[] A = Array.ConvertAll(s.Split(' '), int.Parse);
            //Console.WriteLine(isSortable(A, A.Length) ? "YES" : "NO");
            //Console.ReadLine();

            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(isSortable(A, n) ? "YES" : "NO");
            }
        }
        static bool isSortable(int[] A, int n)
        {
            int j = 0;
            for (int i = 0; i < n-1; i++)
            {
                for (j = i; A[j] != i + 1; j++) ;

                rotate(A, j);
                if (!isSorted(A, i))
                    return false;

            }

            return true;
        }

        static void rotate(int[] A, int pos)
        {
            int temp = A[pos];
            int c;

            while(temp != pos+1)
            {
                c = pos + 1;

                if (c >= A.Length)
                    rotateC(A, pos);
                else
                    rotateB(A, pos);

                pos--;
            }
        }

        static void rotateC(int[] A, int pos)
        {
            int temp = A[pos];
            A[pos] = A[pos - 2];
            A[pos - 2] = A[pos - 1];
            A[pos - 1] = temp;
        }

        static void rotateB(int[] A, int pos)
        {
            rotateC(A, ++pos);
        }

        static bool isSorted(int[] A, int pos)
        {
            int k = 2;
            for (int i = pos - k; i <= pos; i++)
            {
                if (pos-1 >= 0 && A[pos] < A[pos - 1])
                    return false;
            }

            return true;
        }

        static void printArr(int[] A)
        {
            Console.WriteLine(string.Join(" ", A));
        }

        //static bool isSortable(int[] A)
        //{
        //    int k = 3;
        //    int ja;
        //    int jb;
        //    for (int i = 0; i < A.Length; i++)
        //    {
        //        ja = i + 1;
        //        jb = i - k + 1;

        //        if(jb >= 0)
        //        {
        //            if (A[jb] == A[i] - 1)
        //                return false;
        //        }
        //        if (ja < A.Length)
        //        {
        //            if (A[ja] == A[i] - 1)
        //                return false;
        //        }
        //    }

        //    return true;
        //}


    }
}
