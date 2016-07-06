using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sumContAndDisc
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] r = sums(new int[] { });
            //Console.WriteLine("{0} {1}", r[0], r[1]);


            int T = int.Parse(Console.ReadLine());
            int n = 0;
            int[] arr;
            int[] res;
            for (int i = 0; i < T; i++)
            {
                n = int.Parse(Console.ReadLine());
                arr = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);

                res = sums(arr);
                Console.WriteLine("{0} {1}",res[0],res[1]);

            }

            Console.Read();
        }

        static int[] sums(int[] A)
        {
            int[] res = new int[2];
            if (A.Length == 0)
                return res;
            res[1] = -1;
            res[1] = A.Where(x => x >= 0).Sum();
            if(res[1] <= 0)
            {
                res[1] = A.Max();
            }
            
            int maxsum = 0, currentsum = 0;

            foreach(int vl in A)
            {
                currentsum += vl;
                if (currentsum < 0)
                    currentsum = 0;
                else if (currentsum > maxsum)
                    maxsum = currentsum;
            }
            res[0] = maxsum;
            if (res[0] <= 0)
            {
                res[0] = A.Max();
            }


            return res;
        }
    }
}
