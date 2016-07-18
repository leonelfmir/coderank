using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace icecreamParlor
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for(int i = 0; i < T; i++)
            {
                int m = int.Parse(Console.ReadLine());
                int n = int.Parse(Console.ReadLine());
                int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
                Console.WriteLine(flavors(A, m));
            }

            Console.Read();
        }

        static string flavors(int[] A, int m)
        {
            Dictionary<int, int> D = new Dictionary<int,int>();
            int complement = 0;
            for(int i = 0; i < A.Length; i++)
            {
                complement = m - A[i];
                if(D.ContainsKey(complement))
                {
                    return (D[complement] + 1) + " " + (i + 1) ;
                }

                if(! D.ContainsKey(A[i]))
                    D.Add(A[i], i);
            }

            return null;
        }
    }
}
