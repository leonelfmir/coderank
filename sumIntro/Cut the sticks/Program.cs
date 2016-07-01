using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cut_the_sticks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 5, 4, 4, 2, 2, 8 };

            cuts(A).ForEach(x => Console.WriteLine(x));
            Console.Read();
        }

        static List<int> cuts(int[] A)
        {
            List<int> res = new List<int>();
            SortedDictionary<int, int> D = new SortedDictionary<int, int>();

            foreach (int vl in A)
            {
                if (!D.ContainsKey(vl))
                    D[vl] = 0;

                D[vl]++;
            }

            int sum = A.Length;

            foreach(KeyValuePair<int,int> kv in D)
            {
                res.Add(sum);
                sum -= kv.Value;
            }

            return res;
        }
    }
}
