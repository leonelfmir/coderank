using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisible_Sum_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = Convert.ToInt32(tokens_n[0]);
            //int k = Convert.ToInt32(tokens_n[1]);
            //string[] a_temp = Console.ReadLine().Split(' ');
            //int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int k = 3;
            int[] a = { 1, 3, 2, 6, 1, 2 };

            Dictionary<int, int> D = new Dictionary<int, int>();
            int mod = 0;
            int res = 0;
            int inverse = 0;
            foreach(int vl in a)
            {
                mod = vl % k;
                if (!D.ContainsKey(mod))
                    D[mod] = 0;

                inverse = (k - mod) % k;
                if(D.ContainsKey(inverse))
                {
                    res += D[inverse];
                }

                D[mod]++;
            }

            Console.WriteLine(res);
            Console.Read();

            
        }
    }
}
