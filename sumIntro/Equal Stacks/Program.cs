using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equal_Stacks
{
    class Program
    {
        static void Main(string[] args)
        {
            test();

        }

        static void test()
        {
            string[] tokens_n1 = "5 3 4".Split(' ');
            int n1 = Convert.ToInt32(tokens_n1[0]);
            int n2 = Convert.ToInt32(tokens_n1[1]);
            int n3 = Convert.ToInt32(tokens_n1[2]);
            string[] h1_temp = "3 2 1 1 1".Split(' ');
            int[] h1 = Array.ConvertAll(h1_temp, Int32.Parse);
            string[] h2_temp = "4 3 2".Split(' ');
            int[] h2 = Array.ConvertAll(h2_temp, Int32.Parse);
            string[] h3_temp = "1 1 4 1".Split(' ');
            int[] h3 = Array.ConvertAll(h3_temp, Int32.Parse);

            List<int[]> Arrs = new List<int[]>();
            Arrs.Add(h1);
            Arrs.Add(h2);
            Arrs.Add(h3);

            int[] S = { h1.Sum(), h2.Sum(), h3.Sum() };
            int[] poss = { 0, 0, 0 };

            while(! (S[0] == S[1] && S[1] == S[2]))
            {
                int max = 0;

                for (int i = 0; i < 3; i++)
                {
                    if (S[i] > S[max])
                        max = i;
                }

                S[max] -= Arrs[max][poss[max]++];
            }

        }
    }
}
