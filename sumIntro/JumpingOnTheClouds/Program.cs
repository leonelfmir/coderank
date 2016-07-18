using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JumpingOnTheClouds
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] c_temp = Console.ReadLine().Split(' ');
            int[] c = Array.ConvertAll(c_temp, Int32.Parse);
            Console.WriteLine(jumps(c));

            Console.Read();
        }

        static int jumps(int[] A)
        {
            int count = 0;
            int pos = 0;
            while(pos < A.Length - 1)
            {
                if(pos+2 < A.Length && A[pos + 2] == 0)
                {
                    pos ++;
                }
                pos++;
                count++;
            }

            return count;
        }
    }
}
