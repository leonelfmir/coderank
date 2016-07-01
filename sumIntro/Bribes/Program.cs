using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bribes
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 3, 2, 4, 1 };
            int res = Bribes(A);
            Console.WriteLine(res == -1?"Too chaotic": res.ToString());
            Console.Read();
        }

        static int Bribes(int[] A)
        {
            int res = 0;
            
            for(int i = A.Length - 1; i > 0; i--)
            {
                for(int j = i-2; j < i; j++)
                {
                    if(j >=0 )
                    {
                        if(A[j] == i+1)
                        {
                            swap(A, j, j + 1);
                            res++;
                        }
                    }
                }
                if (A[i] != i + 1)
                    return -1;
            }



            return res;
        }

        static void swap(int[] A, int pos1, int pos2)
        {
            int temp = A[pos1];
            A[pos1] = A[pos2];
            A[pos2] = temp;
        }
    }
}
