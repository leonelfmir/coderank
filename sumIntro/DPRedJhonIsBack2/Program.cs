using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPRedJhonIsBack2
{
    class Program
    {
        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine(sol(n));
            }

            Console.ReadLine();
        }

        static int sol(int n)
        {
            return 0;
        }

        Dictionary<Tuple<int, int, int>, List<char[]>> D = new Dictionary<Tuple<int, int, int>, List<char[]>>();//total, x, y

        //static int sort2(int x, int y, int total)
        //{
        //    Tuple<int, int, int> temp = new Tuple<int, int, int>(total, x, y);

        //    for
        //}

        //static HashSet<char[]> HS = new HashSet<char[]>();

        //static void forHelper(int[] x, int[] y, int total, int posX, int posY)
        //{

        //}
    }
}
