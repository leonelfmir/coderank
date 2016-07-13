using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_Divisible_Subset
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = { 2,0,1,1, 7, 2, 4 };
            //int k = 3;
            //int[] arr = { 1, 7 };

            string[] nk_temp = Console.ReadLine().Split(' ');
            int[] nk = Array.ConvertAll(nk_temp, Int32.Parse);
            int n = nk[0];
            int k = nk[1];
            string[] arr_temp = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            Dictionary<int, int> D = new Dictionary<int, int>();
            int mod = 0;
            foreach(int vl in arr)
            {
                mod = vl % k;
                if (!D.ContainsKey(mod))
                    D[mod] = 0;
                D[mod]++;
            }

            HashSet<int> saved = new HashSet<int>();

            int res = sumSets(D, 0, saved, k);

            Console.WriteLine(res);

            Console.Read();
        }

        static int sumSets(Dictionary<int, int> D, int pos, HashSet<int> saved, int k)
        {
            if (pos == D.Keys.Count)
                return 0;

            int without = sumSets(D, pos + 1, new HashSet<int>(saved), k);
            int with = 0;

            int vl = D.Keys.ElementAt(pos);
            int complement = k - vl;

            if (!saved.Contains(complement))
            {
                HashSet<int> tempHsW = new HashSet<int>(saved);
                tempHsW.Add(vl);
                with = D[vl] + sumSets(D, pos + 1, tempHsW, k);
            }

            return Math.Max(with, without);
        }
    }
}
