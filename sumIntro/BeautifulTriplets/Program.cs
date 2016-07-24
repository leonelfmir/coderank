using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulTriplets
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int[] B = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Console.WriteLine(triplets(B, A[1]));

            Console.Read();
        }

        static int triplets(int[] B, int d)
        {
            HashSet<int> hs = new HashSet<int>(B);
            return hs.Count(x => (hs.Contains(x - d) && hs.Contains(x + d)));
        }
    }
}
