using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nim
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());
            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(Console.ReadLine());
                int[] S = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
                Console.WriteLine(winner(S) ? "Second" : "First");
            }
            //    int[] A = { 1,1 };
            //Console.WriteLine(winner(A)? "Second": "First");
            //Console.Read();
        }

        //static bool winner(int[] A, bool expected, Dictionary<int[], bool> D)
        //{
        //    if (D.ContainsKey(A))
        //        return D[A];
        //    var sm = A.Count(x => x > 0);
        //    if (sm == 1)
        //    {
        //        D[A] = false;
        //        return D[A];
        //    }

        //    if (A.Max() == 0)
        //    {
        //        D[A] = true;
        //        return D[A];
        //    }

        //    for (int i = 0; i < A.Length; i++)
        //    {
                    
        //    }

        //    return D[A];
        //}

        static bool winner(int[] A)
        {
            var res = A.Aggregate((x, y) => x ^ y);

            return res >0?false:true;
        }
    }
}
