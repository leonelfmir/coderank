using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace minimumDistanceArr
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 7, 1, 2, 4, 0,2, 7 };

            Console.Write(minDist(A));
            
            Console.Read();
        }

        static int minDist(int[] A)
        {
            Dictionary<int, List<int>> D = new Dictionary<int, List<int>>();

            for(int i = 0; i < A.Length; i++)
            {
                if (!D.ContainsKey(A[i]))
                    D[A[i]] = new List<int>();

                D[A[i]].Add(i);
            }

            int min = int.MaxValue;
            foreach(KeyValuePair<int, List<int>> kv in D)
            {
                for(int i = 1; i < kv.Value.Count; i++)
                {
                    if (kv.Value[i] - kv.Value[i - 1] < min)
                        min = kv.Value[i] - kv.Value[i - 1];
                }
            }

            return min == int.MaxValue?-1:min;
        }
    }
}
