using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Non_DivisbleSubset_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int k = 4;
            //int[] arr = { 6, 5, 2, 3, 7, 12, 17, 22 };

            //string[] nk_temp = Console.ReadLine().Split(' ');
            //int[] nk = Array.ConvertAll(nk_temp, Int32.Parse);
            //int n = nk[0];
            //int k = nk[1];
            //string[] arr_temp = Console.ReadLine().Split(' ');
            //int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

            Dictionary<int, int> D = new Dictionary<int, int>();
            int mod = 0;
            foreach (int vl in arr)
            {
                mod = vl % k;
                if (!D.ContainsKey(mod))
                    D[mod] = 0;
                D[mod]++;
            }

            HashSet<int> chosen = new HashSet<int>();
            int res = 0;
            
            foreach(KeyValuePair<int,int> kv in D)
            {
                

                int complement = k - kv.Key;
                if (chosen.Contains(complement) || chosen.Contains(kv.Key))
                    continue;

                if (kv.Key == 0 || kv.Key * 2 == k)
                {
                    chosen.Add(kv.Key);
                    res++;
                }
                else
                {
                    int complementValue = D.ContainsKey(complement) ? D[complement] : 0;

                    if (complementValue > kv.Value)
                    {
                        chosen.Add(complement);
                        res += complementValue;
                    }
                    else
                    {
                        chosen.Add(kv.Key);
                        res += kv.Value;
                    }
                }
            }

            Console.WriteLine(res);

            Console.Read();
        }
    }
}
