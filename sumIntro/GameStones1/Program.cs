using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStones1
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int mod = n % 7;

                Console.WriteLine("{0}",mod < 2 ? "Second" : "First");
            }

            Console.ReadLine();
        }
    }
}
