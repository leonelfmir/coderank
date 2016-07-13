using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort2
{
    class Program
    {
        static void Main(String[] args)
        {

            int _ar_size;
            _ar_size = Convert.ToInt32(Console.ReadLine());
            int[] _ar = new int[_ar_size];
            String elements = Console.ReadLine();
            String[] split_elements = elements.Split(' ');
            for (int _ar_i = 0; _ar_i < _ar_size; _ar_i++)
            {
                _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]);
            }

            insertionSort(_ar);
            Console.Read();
        }

        static void insertionSort(int[] A)
        {
            for(int i = 1; i < A.Length;i++)
            {
                int temp = A[i];
                for(int j = i-1; j >=0; j--)
                {
                    if(temp < A[j])
                    {
                        A[j + 1] = A[j];
                        A[j] = temp;
                    }
                }
                //printArr(A);
                Console.WriteLine(String.Join(" ", A));
            }
        }

        static void printArr(int[] A)
        {
            foreach (int vl in A)
            {
                Console.Write(vl + " ");
            }
            Console.WriteLine();
            
        }
    }
}
