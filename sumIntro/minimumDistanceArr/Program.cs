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

            int max = -1;
            foreach(KeyValuePair<int, List<int>> kv in D)
            {
                for(int i = 1; i < kv.Value.Count; i++)
                {
                    if()
                }
            }
        }
    }
}
