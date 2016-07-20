using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace coinChange
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] C = { 1, 5, 10};
            //while (true)
            //{
            //    int m = int.Parse(Console.ReadLine());
            //    Console.WriteLine(waysOfChange(m, C));
            //}
            int[] nm = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            int n = nm[0];
            int[] C = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(waysOfChange(n, C));
            Console.Read();
        }

        static BigInteger waysOfChange(int m, int[] C)
        {
            Array.Sort(C);
            Dictionary<Tuple<int,int>, BigInteger> D = new Dictionary<Tuple<int, int>, BigInteger>();

            return changes(m, C.Length-1, C, D);

        }

        static BigInteger changes(int m, int coin, int[] C, Dictionary<Tuple<int, int>, BigInteger> D)
        {
            Tuple<int, int> tempKey = new Tuple<int, int>(m, coin);
            if (D.ContainsKey(tempKey))
                return D[tempKey];

            if (coin == 0)
            {
                if (m % C[coin] == 0)
                    return D[tempKey] = 1;

                return D[tempKey] = 0;
            }

            BigInteger sum = 0;
            while(m >= 0)
            {
                sum += changes(m, coin - 1, C, D);
                m -= C[coin];
            }

            return D[tempKey] = sum;
        }
        
    }
}
