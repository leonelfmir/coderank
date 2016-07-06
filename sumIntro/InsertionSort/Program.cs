using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 4, 4, 6, 8, 3};
            insertionSort(A);
            Console.Read();
        }

        static void insertionSort(int[] ar)
        {
            int t = ar[ar.Length - 1];
            bool br = false;
            for(int i = ar.Length - 2; i >=-1; i--)
            {
                if(i == -1)
                {
                    ar[i + 1] = t;
                }
                else if (ar[i] > t)
                    ar[i + 1] = ar[i];
                else
                {
                    ar[i + 1] = t;
                    br = true;
                }

                foreach(int vl in ar)
                {
                    Console.Write(vl);
                }
                Console.WriteLine();

                if (br)
                    break;
            }

        }
    }
}
