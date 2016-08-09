using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPHackerRankCity
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            int[] A = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(sol(n, A));
            Console.ReadLine();
        }

        static long sol(int n, int[] A)
        {
            long sum = 0;
            long distance = 0;
            long count = 1;

            
            for (int i = 0; i < n; i++)
            {
                long[] MUD = mirrorUD(distance, sum, count, A[i]);
                count = count * 2 + 1;
                sum = MUD[0];
                distance = MUD[1];
            }

            return sum;
        }

        static long[] mirrorUD(long currentDist, long sum, long amountToMirrow, int distance)
        {
            long rDist = currentDist + (amountToMirrow * distance);
            long rSum = sum + rDist;
            return new long[] { rSum, rDist };
        }

        //static long sol(int n, int[] A)
        //{

        //    Dictionary<long, long> points = new Dictionary<long, long>();
        //    HashSet<CP> CPS = new HashSet<CP>();
        //    //points[6] = 29;
        //    Queue<CP> Q = new Queue<CP>();
        //    Q.Enqueue(new CP(1));

        //    for (int i = 1; i <= n; i++)
        //    {

        //    }

        //}

        //static int step(int n, int[] A, Dictionary<long, long> points, HashSet<CP> CPS)
        //{

        //}
        //static long connect(int cp, int d, Dictionary<long, long> points)
        //{

        //}

    }

    //class CP
    //{
    //    public long number = 0;
    //    public bool[] cn = new bool[4];
    //    public long[] cnNumber = new long[4];

    //    public CP(long n)
    //    {
    //        number = n;
    //    }

    //}

}
