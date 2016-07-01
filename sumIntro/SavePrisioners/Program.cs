using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavePrisioners
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 1, 1 };
            prisioner(A);
            Console.Read();

            //int T = Convert.ToInt32(Console.ReadLine());
            //string[] arr_temp = Console.ReadLine().Split(' ');
            //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);
            //int N = arr[0];
            //int M = arr[1];
            //int S = arr[2];

            //for(int i = 0; i < T; i++)
            //    Console.WriteLine((S + M - 1) % N);
        }

        static void prisioner(int[] arr)
        {

            int N = arr[0];
            int M = arr[1];
            int S = arr[2];

            int p = (S - 1 + M) % N;
            Console.WriteLine(p == 0? N: p);
        }
    }
}
