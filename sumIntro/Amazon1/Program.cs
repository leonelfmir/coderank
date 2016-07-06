using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon1
{
    class Program
    {
        static void Main(string[] args)
        {


            //for(int i = N.Length - 1; i > 0; i--)
            //{
            //    N[i] = N[i] - N[i - 1];
            //}
            //N[0] = 0;

            int[] N = { 1, 3, 1, 2 };
            int max= N.Last();
            int sum = 0;

            for (int i = N.Length - 2 ; i >= 0; i--)
            {
                if (N[i] < max)
                    sum++;
                else
                    max = N[i];
            }

            Console.WriteLine(sum);

            Console.ReadLine();
        }
    }
}
