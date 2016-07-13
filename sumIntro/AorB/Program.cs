using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AorB
{
    public class Program
    {
        static void Main(string[] args)
        {

            int t = Convert.ToInt32(Console.ReadLine());
            for (int a0 = 0; a0 < t; a0++)
            {
                int k = Convert.ToInt32(Console.ReadLine());
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                string c = Console.ReadLine();

                abc(k, a, b, c);

            }
            Console.Read();
        }

        static void abc(int k, string a, string b, string c)
        {
            Int64 ai = Convert.ToInt64(a, 16);
            Int64 bi = Convert.ToInt64(b, 16);
            Int64 ci = Convert.ToInt64(c, 16);

            int min = minimumchanges(ref ai, ref bi, ci);

            if (min > k)
            {
                Console.WriteLine("-1");
                return;
            }

            if (min < k)
            {
                minimize(ref ai, ref bi, k - min);
            }

            string[] res = { string.Format("{0:X}", ai), string.Format("{0:X}", bi)};

            Console.WriteLine(res[0]);
            Console.WriteLine(res[1]);
            
        }

        static int minimumchanges (ref Int64 a, ref Int64 b, Int64 c)
        {
            Int64 max = Math.Max(a, Math.Max(b, c));
            int counter = 0;
            int k = 0;
            while (max > 0)
            {
                if ((c & 1) == 1)
                {
                    //a = 0 and b == 0
                    //make b = 1;
                    if (((a & ((Int64)1 << counter)) == 0) && ((b & ((Int64)1 << counter)) == 0))
                    {
                        b |= ((Int64)1 << counter);
                        k++;
                    }
                }
                else
                {
                    //a = 1
                    //make a = 0;
                    if ((a & ((Int64)1 << counter)) != 0)
                    {
                        a &= ~((Int64)1 << counter);
                        k++;
                    }
                    //b = 1
                    //make b = 0;
                    if ((b & ((Int64)1 << counter)) != 0)
                    {
                        b &= ~((Int64)1 << counter);
                        k++;
                    }

                }
                c >>= 1;
                max >>= 1;
                counter++;
            }

            return k;
        }

        static void minimize(ref Int64 a, ref Int64 b, int changes)
        {
            for(int i = 63; i >=0; i--)
            {
                if (changes == 0)
                    break;

                //a = 1 and b == 1
                //make a = 0;
                if (((a & ((Int64)1 << i)) != 0) && ((b & ((Int64)1 << i)) != 0))
                {
                    a&= ~((Int64)1 << i);
                    changes--;
                }
                //a = 1 and b == 0
                //make b = 0;
                else if (((a & ((Int64)1 << i)) != 0) && ((b & ((Int64)1 << i)) == 0))
                {
                    if (changes > 1)
                    {
                        b |= ((Int64)1 << i);
                        a &= ~((Int64)1 << i);
                        changes -= 2;
                    }
                }
            }
        }

        static void printb(Int64 b, string nm)
        {
            Console.WriteLine("{0} = {1}",nm, Convert.ToString(b, 2).PadLeft(66,'0'));
        }
    }
}
