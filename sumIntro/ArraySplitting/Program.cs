using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ArraySplitting
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "08";
            string[] lines = System.IO.File.ReadAllLines("input" + path + ".txt");
            int t = int.Parse(lines[0]);
            string[] s = new string[t];
            int x = 0;
            for (int i = 1; i < t * 2; i += 2)
            {
                int n = int.Parse(lines[i]);
                int[] A = Array.ConvertAll(lines[i + 1].Split(' '), Int32.Parse);
                s[x++] = partionArray(A).ToString();
            }

            System.IO.File.WriteAllText("Output" + path + ".txt", string.Join("\n", s));



            Console.WriteLine("Done");
            //int[] B = Array.ConvertAll("0 0 0".Split(' '), int.Parse);
            //Console.WriteLine(partionArray(B));

            //int t = int.Parse(Console.ReadLine());
            //for (int i = 0; i < t; i++)
            //{
            //    int n = int.Parse(Console.ReadLine());
            //    int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
            //    Console.WriteLine(partionArray(A));
            //}
            Console.Read();
        }

        static int partionArray(int[] arr)
        {
            BigInteger sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }

            return partition(arr, sum);
        }

        static int partition(int[] A, BigInteger sum)
        {
            if (A.Length == 1)
                return 0;
            if ((sum & 1) == 1)
                return 0;
            if (sum == 0)
                return A.Length - 1;

            BigInteger tempSum = 0;
            int i = 0;
            for (; i < A.Length; i++)
            {
                tempSum += A[i];
                sum -= A[i];
                if(tempSum >= sum)
                {
                    break;
                }
            }

            if(tempSum == sum)
            {
                int[] left = new int[i+1];
                int[] right = new int[A.Length - i - 1];
                Array.Copy(A, left, i);
                Array.Copy(A, i+1,right, 0, right.Length);

                return Math.Max(partition(left, sum), partition(right, sum)) + 1;
            }

            return 0;
        }
    }
}
