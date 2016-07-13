using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopian_Tree
{
    public class Program
    {
        static void Main(string[] args)
        {
            //int t = Convert.ToInt32(Console.ReadLine());
            //for (int a0 = 0; a0 < t; a0++)
            //{
            //    int n = Convert.ToInt32(Console.ReadLine());

            //    Console.WriteLine(n * 2 - n / 2 + 1);
            //}

            int res = 0;
            Dictionary<int, int> D = new Dictionary<int, int>();
            for (int n = 0; n < 500; n++)
            {
                res += (n & 1) == 1 ? res : 1;

                Console.WriteLine("{0} = {1} -- {2}", n, res, TreeHeight(D, n));
                

            }

            Console.Read();

        }

        static int TreeHeight(Dictionary<int, int> D, int n)
        {
            if (D.ContainsKey(n))
                return D[n];
                
            if (n == 0)
                return D[n] = 1;


            return D[n] = ((n & 1) == 1) ? TreeHeight(D, n - 1) * 2 : TreeHeight(D, n - 1) + 1;

        }
    }
}
