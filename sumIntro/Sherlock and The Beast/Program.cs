using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//A Decent Number has the following properties:

//Its digits can only be 3's and/or 5's.
//The number of 3's it contains is divisible by 5.
//The number of 5's it contains is divisible by 3.
//If there are more than one such number, we pick the largest one.

namespace Sherlock_and_The_Beast
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 1; i < 25; i++)
                Console.WriteLine(number(i));

            //var it = GetCounter();

            //while (it.MoveNext())
            //    Console.Write(it.Current);




            Console.Read();
        }

        static string number(int n)
        {
            char n1 = '5';
            //char n2 = '3';
            Dictionary<int, List<string>> D = new Dictionary<int, List<string>>();
            string number = new string(n1, n);
            
            var cm = combinations(number, n, D);

            while(cm.MoveNext())
            {
                if (isDecentNumber(cm.Current))
                    return cm.Current;
            }

            return "-1";
            //string copyArr = new char[number.Length];

            //if (isDecentNumber(number))
            //    return int.Parse(new string(number));

            //char temp = n1;
            //for(int i = n-1; i >=0; i--)
            //{
            //    number.CopyTo(copyArr, 0);

            //    for(int j = n-1; j >= i; j--)
            //    {
            //        number[j] = number[j] == n1 ? n2 : n1;
            //        Console.WriteLine("Number: " + new string(number));
            //        if (isDecentNumber(number))
            //            return int.Parse(new string(number));

            //    }
            //}

            //return -1;
        }
        

        static bool isDecentNumber(string A)
        {
            char n1 = '5';
            char n2 = '3';

            int cn1 = 0;
            int cn2 = 0;

            foreach(char c in A)
            {
                if (c == n1)
                    cn1++;
                else
                    cn2++;
            }

            if (cn2 % 5 == 0 && cn1 % 3 == 0)
                return true;

            return false;
        }

       
        static IEnumerator<string> combinations(string A, int pos, Dictionary<int, List<string>> D)
        {
            if (pos == 1)
            {
                D[pos] = new List<string>();

                D[pos].Add("5");
                yield return (D[pos].Last());

                D[pos].Add("3");
                yield return (D[pos].Last());
            }
            else
            {
                if (D.ContainsKey(pos))
                {
                    foreach (string vl in D[pos])
                        yield return vl;
                }
                else
                {
                    D[pos] = new List<string>();

                    if (!D.ContainsKey(pos - 1))
                    {
                        var temp = combinations(A, pos - 1, D);
                        while (temp.MoveNext())
                        {
                            D[pos].Add(string.Concat(temp.Current, 5));
                            yield return (D[pos].Last());
                            D[pos].Add(string.Concat(temp.Current, 3));
                            yield return (D[pos].Last());

                        }
                    }
                }
            }

            
        }

        //static IEnumerator<char[]> GetCounter(char[] A)
        //{
        //    for (int n = 0; n<stop; n++)
        //yield return n;
        //}
        //
        //static List<string> combinations(string A, int pos, Dictionary<int, List<string>> D)
        //{
        //    if (pos == 0)
        //    {
        //        D[pos] = new List<string>();
        //        D[pos].Add("5");
        //        D[pos].Add("3");
        //    }
        //    else
        //    {
        //        D[pos] = new List<string>();

        //        if (!D.ContainsKey(pos - 1))
        //        {
        //            combinations(A, pos - 1, D);
        //        }

        //        foreach (string vl in D[pos - 1])
        //        {
        //            D[pos].Add(string.Concat(vl, 5));
        //            D[pos].Add(string.Concat(vl, 3));
        //        }
        //    }

        //    return D[pos];
        //}

    }
}
