using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] N = { 2, 3, 10, 2, 4, 8, 1 };

            int max = N.Last();
            int maxdiff = int.MinValue;

            for (int i = N.Length - 2; i >=0; i--)
            {
                if(N[i] > max)
                {
                    max = N[i];
                }
                else
                {
                    maxdiff = Math.Max(maxdiff, max - N[i]);
                }
                
            }

            Console.WriteLine(maxdiff);
            Console.ReadLine();
        }
    }
}
